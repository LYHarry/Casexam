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


        public string ReqTypeName { get; set; }

        public string RespTypeName { get; set; }

        public string ReqData { get; set; }
    }
}
