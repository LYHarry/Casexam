using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure.Attrs
{
    /// <summary>
    /// 参数别名注入特性
    /// 单接口多实现时注入某个指定的服务实例
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class ParameterAliasInjectAttribute : PropertyInjectAttribute
    {
        /// <summary>
        /// 特定的服务实例类型
        /// </summary>
        public Type AliasType { get; }

        /// <summary>
        /// 单接口多实现时注入某个指定的服务实例
        /// </summary>
        /// <param name="type">特定的服务实例类型</param>
        public ParameterAliasInjectAttribute(Type type)
        {
            AliasType = type;
        }
    }
}
