using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Infrastructures.Server.RPC
{
    /// <summary>
    /// rpc 调用方法后结果返回类
    /// </summary>
    public class RpcCallMethodResult
    {
        public string Ex { get; set; }

        public string ExMessage { get; set; }

        public bool IsSuccess { get; set; }

        public string ResData { get; set; }
    }
}
