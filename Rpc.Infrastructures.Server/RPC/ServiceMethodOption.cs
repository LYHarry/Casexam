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

        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; }

        public Type ServiceType { get; set; }
    }
}
