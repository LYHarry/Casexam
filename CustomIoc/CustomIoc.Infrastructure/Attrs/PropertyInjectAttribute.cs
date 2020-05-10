using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure.Attrs
{
    /// <summary>
    /// 属性注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInjectAttribute : Attribute
    {

    }
}
