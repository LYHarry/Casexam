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
        private readonly RpcServiceOptions _rpcServices;

        public ServiceRequestClient(IOptions<RpcServiceOptions> rpcServiceOptions)
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
            Channel channel = new Channel("127.0.0.1:9007", ChannelCredentials.Insecure);
            var client = new CallRpcService.CallRpcServiceClient(channel);
            var reply = client.Run(new RpcRequestData()
            {
                ReqData = JsonConvert.SerializeObject(new RpcMsgContext()
                {
                    ReqData = JsonConvert.SerializeObject(request),
                    ReqTypeName = typeof(TRequest).FullName,
                    RespTypeName = typeof(TResponse).FullName
                })
            });
            var result = JsonConvert.DeserializeObject<RpcCallMethodResult>(reply.RepData);
            if (!result.IsSuccess)
                throw new Exception(result.ExMessage);

            return Task.FromResult(JsonConvert.DeserializeObject<TResponse>(result.ResData));
        }
    }
}
