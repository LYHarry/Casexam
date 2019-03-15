using Grpc.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rpc.Infrastructures.Server.RPC;
using Rpc.Protocols;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Server.RequestClient
{
    /// <summary>
    /// 服务请求客户端
    /// </summary>
    public class ServiceRequestClient : IServiceRequestClient
    {
        private readonly List<ServiceSiteOption> _rpcServices;

        public ServiceRequestClient(IOptions<List<ServiceSiteOption>> rpcServiceOptions)
        {
            _rpcServices = rpcServiceOptions.Value;
        }

        /// <summary>
        /// 请求服务接口
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        {
            return RpcInvokeAsync<TRequest, TResponse>(request);
        }

        /// <summary>
        /// rpc 服务请求调用
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private Task<TResponse> RpcInvokeAsync<TRequest, TResponse>(TRequest request)
        {
            Channel channel = new Channel("127.0.0.1:9401", ChannelCredentials.Insecure);
            var client = new CallRpcService.CallRpcServiceClient(channel);
            //创建rpc请求消息上下文
            var rpcContext = new RpcMsgContext()
            {
                ReqData = JsonConvert.SerializeObject(request),
                ReqType = typeof(TRequest),
                RespTypeName = typeof(TResponse).FullName
            };
            if (request == null)
            {
                if (typeof(TRequest) != typeof(object))
                    throw new Exception("请求参数为空时请求类型必须为 object 类型.");
                rpcContext.ReqData = string.Empty;
                rpcContext.ReqType = null;
            }
            var reply = client.Run(new RpcRequestData()
            {
                ReqData = JsonConvert.SerializeObject(rpcContext)
            });
            var result = JsonConvert.DeserializeObject<RpcCallMethodResult>(reply.RespData);
            if (!result.IsSuccess)
                throw new Exception(result.ExMessage);

            return Task.FromResult(JsonConvert.DeserializeObject<TResponse>(result.ResData));
        }
    }
}
