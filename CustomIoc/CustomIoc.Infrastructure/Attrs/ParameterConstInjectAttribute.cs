using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure.Attrs
{
    /// <summary>
    /// 常量参数注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParameterConstInjectAttribute : Attribute
    {
        /// <summary>
        /// 参数所在位置下标
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="paramIndex">参数所在位置下标</param>
        public ParameterConstInjectAttribute(int paramIndex)
        {
            Index = paramIndex;
        }
    }
}
