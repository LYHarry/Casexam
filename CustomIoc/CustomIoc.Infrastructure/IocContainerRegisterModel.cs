using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure
{
    /// <summary>
    /// IOC容器注册模型
    /// </summary>
    public class IocContainerRegisterModel
    {
        /// <summary>
        /// 目标实例类型
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// 服务生命周期
        /// </summary>
        public ServiceLifetime Lifetime { get; set; }

        /// <summary>
        /// 单例实例对象
        /// </summary>
        public object SingletonObject { get; set; }
    }
}
