using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Infrastructures.Server.RPC
{
    /// <summary>
    /// 服务地址
    /// </summary>
    public class ServiceSiteOption
    {
        /// <summary>
        /// ip地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
    }
}
