using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.ViewModels
{
    /// <summary>
    /// 服务返回状态
    /// </summary>
    public enum ServiceStatus
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failure = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1
    }
}
