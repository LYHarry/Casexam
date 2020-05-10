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
        /// 注册单例服务实例
        /// </summary>
        void RegisterSingleton<TForm, TTo>(params object[] constParams) where TForm : class where TTo : TForm;

        /// <summary>
        ///注册请求单例(容器单例)服务实例
        /// </summary>
        void RegisterScoped<TForm, TTo>(params object[] constParams) where TForm : class where TTo : TForm;

        /// <summary>
        /// 注册瞬时服务实例
        /// </summary>
        void RegisterTransient<TForm, TTo>(params object[] constParams) where TForm : class where TTo : TForm;

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <typeparam name="TForm">服务类型</typeparam>
        /// <typeparam name="TTo">实例化类型</typeparam>
        [Obsolete]
        void Register<TForm, TTo>(ServiceLifetime lifetime = ServiceLifetime.Transient, params object[] constParams)
            where TForm : class where TTo : TForm;

        /// <summary>
        /// 生成对象
        /// </summary>
        /// <typeparam name="TForm">服务类型</typeparam>
        /// <returns></returns>
        TForm Resolve<TForm>(Type toType = null) where TForm : class;

        /// <summary>
        /// 创建子容器实现容器单例
        /// </summary>
        /// <returns></returns>
        ICustomIocContainers CreateChildContainer();
    }
}
