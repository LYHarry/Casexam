using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Infrastructures.Server.RPC
{
    /// <summary>
    /// 服务方法项
    /// </summary>
    public class ServiceMethodOption
    {
        /// <summary>
        /// 请求参数类型
        /// </summary>
        public Type ReqType { get; set; }

        /// <summary>
        /// 返回参数类型
        /// </summary>
        public Type RespType { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }

        public string Namespace { get; set; }

        /// <summary>
        /// 所属服务类型
        /// </summary>
        public Type ServiceType { get; set; }
    }
}
