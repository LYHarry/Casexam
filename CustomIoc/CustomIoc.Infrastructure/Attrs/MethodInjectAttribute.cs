using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure.Attrs
{
    /// <summary>
    /// 方法注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodInjectAttribute : Attribute
    {

    }
}
