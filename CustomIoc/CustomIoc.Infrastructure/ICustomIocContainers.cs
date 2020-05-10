using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Infrastructure
{
    /// <summary>
    /// 自定义容器
    /// </summary>
    public interface ICustomIocContainers
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <typeparam name="TForm">服务类型</typeparam>
        /// <typeparam name="TTo">实例化类型</typeparam>
        void Register<TForm, TTo>(params object[] constParams)
            where TForm : class where TTo : TForm;

        /// <summary>
        /// 生成对象
        /// </summary>
        /// <typeparam name="TForm">服务类型</typeparam>
        /// <returns></returns>
        TForm Resolve<TForm>(Type toType = null) where TForm : class;
    }
}
