using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Infrastructures.Server.RPC
{
    /// <summary>
    ///  rpc 消息上下文
    /// </summary>
    public class RpcMsgContext
    {
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 方法请求类型名称
        /// </summary>
        public string ReqTypeName { get; set; }

        /// <summary>
        /// 方法响应类型名称
        /// </summary>
        public string RespTypeName { get; set; }

        /// <summary>
        /// 方法请求参数
        /// </summary>
        public string ReqData { get; set; }
    }
}
