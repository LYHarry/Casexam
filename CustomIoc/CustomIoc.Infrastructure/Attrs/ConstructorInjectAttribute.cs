using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure.Attrs
{
    /// <summary>
    /// 构造函数注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ConstructorInjectAttribute : Attribute
    {

    }
}
