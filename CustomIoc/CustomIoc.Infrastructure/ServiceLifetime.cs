using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure
{
    /// <summary>
    /// 服务生命周期
    /// </summary>
    public enum ServiceLifetime
    {
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,

        /// <summary>
        ///请求单例(容器单例)
        /// </summary>
        Scoped,

        /// <summary>
        /// 瞬时的
        /// </summary>
        Transient
    }
}
