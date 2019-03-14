using AspectCore.Injector;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Rpc.Infrastructures.Repository;
using Rpc.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Server.RPC
{
    public class CallRpcServiceImpl : CallRpcService.CallRpcServiceBase
    {
        private readonly IServiceResolver _serviceResolver;
        private readonly List<ServiceMethodOption> _serviceMethods;

        public CallRpcServiceImpl(IServiceResolver serviceResolver, List<ServiceMethodOption> serviceMethods)
        {
            _serviceResolver = serviceResolver;
            _serviceMethods = serviceMethods;
        }

        /// <summary>
        /// 调用服务方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<RpcReplyData> Run(RpcRequestData request, ServerCallContext context)
        {
            var callResult = new RpcCallMethodResult();
            using (var scope = _serviceResolver.CreateScope())
            {
                var unitOfWork = scope.GetService<IUnitOfWork>();
                try
                {
                    var rpcContext = JsonConvert.DeserializeObject<RpcMsgContext>(request.ReqData);
                    var rpcCallMethod = _serviceMethods.Where(x => x.RespType.FullName == rpcContext.RespTypeName
                                                                   && x.ReqType.FullName == rpcContext.ReqTypeName)
                                                       .FirstOrDefault();
                    if (rpcCallMethod == null)
                        throw new Exception("Rpc Call Method Not Find");

                    var service = scope.GetService(rpcCallMethod.ServiceType.GetInterface($"I{rpcCallMethod.ServiceType.Name}"));
                    var proxyMethod = service.GetType().GetMethod(rpcCallMethod.MethodName);

                    var reqData = JsonConvert.DeserializeObject(rpcContext.ReqData, rpcCallMethod.ReqType);
                    if (!(proxyMethod.Invoke(service, new[] { reqData }) is Task resultTask))
                        throw new Exception("Rpc Call Method Result Task Is Null");

                    var result = resultTask.GetType().GetProperty("Result").GetValue(resultTask);
                    callResult.IsSuccess = true;
                    callResult.ResData = JsonConvert.SerializeObject(result);
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    callResult.IsSuccess = false;
                    callResult.ResData = string.Empty;
                    callResult.Ex = ex.ToString();
                    callResult.ExMessage = ex.InnerException?.Message ?? ex.Message;
                }
                return Task.FromResult(new RpcReplyData
                {
                    RespData = JsonConvert.SerializeObject(callResult)
                });
            }
        }
    }
}
