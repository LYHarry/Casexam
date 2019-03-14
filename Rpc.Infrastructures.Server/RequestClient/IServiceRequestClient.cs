using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Server.RequestClient
{
    /// <summary>
    /// 服务请求客户端
    /// </summary>
    public interface IServiceRequestClient
    {
        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request);
    }
}
