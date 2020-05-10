using CustomIoc.Infrastructure.Attrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomIoc.Infrastructure.Impl
{
    /// <summary>
    /// 自定义容器
    /// </summary>
    public class CustomIocContainers : ICustomIocContainers
    {
        /// <summary>
        /// 容器集合字典
        /// key: TForm 的全命名空间名称
        /// value: TTo 类型
        /// </summary>
        private readonly Dictionary<string, IocContainerRegisterModel> _containerDict = new Dictionary<string, IocContainerRegisterModel>();

        /// <summary>
        /// 常量参数集合字典
        /// </summary>
        private readonly Dictionary<string, object[]> _constParamDict = new Dictionary<string, object[]>();

        /// <summary>
        /// 容器单例实例对象集合字典
        /// </summary>
        private readonly Dictionary<string, object> _scopeDict = new Dictionary<string, object>();


        /// <summary>
        /// CustomIocContainers 容器构造函数
        /// </summary>
        public CustomIocContainers()
        {
            Console.WriteLine("CustomIocContainers.Constructor 无参构造");
        }

        /// <summary>
        /// 创建子容器实现容器单例
        /// </summary>
        /// <returns></returns>
        public ICustomIocContainers CreateChildContainer()
        {
            return new CustomIocContainers(_containerDict, _constParamDict);
        }

        /// <summary>
        /// 私有构造函数，用于创建子容器时，保存父容器服务实例
        /// </summary>
        /// <param name="iocContainerDict">容器服务集合</param>
        /// <param name="constParamDict">服务常量参数集合</param>
        private CustomIocContainers(
            Dictionary<string, IocContainerRegisterModel> iocContainerDict,
            Dictionary<string, object[]> constParamDict)
        {
            _containerDict = iocContainerDict;
            _constParamDict = constParamDict;
            _scopeDict = new Dictionary<string, object>();
        }


        /// <summary>
        /// 注册单例服务实例
        /// </summary>
        public void RegisterSingleton<TForm, TTo>(params object[] constParams) where TForm : class where TTo : TForm
        {
            Register<TForm, TTo>(ServiceLifetime.Singleton, constParams);
        }

        /// <summary>
        ///注册请求单例(容器单例)服务实例
        /// </summary>
        public void RegisterScoped<TForm, TTo>(params object[] constParams) where TForm : class where TTo : TForm
        {
            Register<TForm, TTo>(ServiceLifetime.Scoped, constParams);
        }

        /// <summary>
        /// 注册瞬时服务实例
        /// </summary>
        public void RegisterTransient<TForm, TTo>(params object[] constParams) where TForm : class where TTo : TForm
        {
            Register<TForm, TTo>(ServiceLifetime.Transient, constParams);
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        public void Register<TForm, TTo>(ServiceLifetime lifetime = ServiceLifetime.Transient, params object[] constParams)
            where TForm : class where TTo : TForm
        {
            var key = GetTFormName(typeof(TForm), typeof(TTo));

            if (!_containerDict.ContainsKey(key))
            {
                _containerDict.Add(key, new IocContainerRegisterModel()
                {
                    TargetType = typeof(TTo),
                    Lifetime = lifetime
                });
            }

            if (constParams != null && constParams.Length > 0 && !_constParamDict.ContainsKey(key))
                _constParamDict.Add(key, constParams);
        }

        /// <summary>
        /// 生成对象
        /// </summary>
        /// <returns></returns>
        public TForm Resolve<TForm>(Type toType = null) where TForm : class
        {
            //创建实例
            var oInstance = CreateInstance(typeof(TForm), toType);
            return (TForm)oInstance;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        private object CreateInstance(Type type, Type toType = null)
        {
            var key = GetTFormName(type, toType);
            if (!_containerDict.ContainsKey(key))
                throw new Exception($"未注册服务{type.FullName}.");

            //得到实例模型对象类型
            var oRegModel = _containerDict[key];
            //如果该单例实例对象存在，则直接返回
            if (oRegModel.Lifetime == ServiceLifetime.Singleton && oRegModel.SingletonObject != null)
            {
                return oRegModel.SingletonObject;
            }
            //如果该容器实例对象存在，则直接返回
            if (oRegModel.Lifetime == ServiceLifetime.Scoped && _scopeDict.ContainsKey(key) && _scopeDict[key] != null)
            {
                return _scopeDict[key];
            }
            //得到实例类型
            var oType = oRegModel.TargetType;

            #region 构造函数注入
            //得到所有的构造函数
            var ctors = oType.GetConstructors();
            #region 多个构造函数时选择方式
            ConstructorInfo assignCtor = null;
            //1、得到第一个构造函数
            //assignCtor = ctors.FirstOrDefault();
            //2、得到无参构造函数
            //assignCtor = ctors.FirstOrDefault(p => p.GetParameters().Length == 0);
            //3、超集(并集，.Net Core 采用方式)
            //4、特性标记
            assignCtor = ctors.FirstOrDefault(p => p.IsDefined(typeof(ConstructorInjectAttribute), true));
            //5、得到参数最多的构造函数
            if (assignCtor == null)
                assignCtor = ctors.OrderByDescending(p => p.GetParameters().Length).FirstOrDefault();
            if (assignCtor == null)
                throw new Exception($"未找到{oType.FullName}构造函数");

            #endregion

            //得到构造函数的所有参数实例
            var ctorParaInstances = GetObjectInstanceParams(assignCtor.GetParameters(), key, oType);

            #endregion

            //创建实例
            var oInstance = Activator.CreateInstance(oType, ctorParaInstances);

            #region 属性注入
            //得到标记了 属性注入特性 的公共属性
            var oProps = oType.GetProperties().Where(p => p.IsDefined(typeof(PropertyInjectAttribute), true)).ToList();
            foreach (var prop in oProps)
            {
                Console.WriteLine($"{oType.FullName} 属性{prop.Name} 注入{prop.PropertyType.Name}类型");
                //当前属性是否指定别名
                var aliasType = GetAliasType(prop);
                //得到属性实例
                var propInstance = CreateInstance(prop.PropertyType, aliasType);
                prop.SetValue(oInstance, propInstance);
            }
            #endregion

            #region 方法注入
            //得到标记了 方法注入特性 的公共方法
            var oMethods = oType.GetMethods().Where(p => p.IsDefined(typeof(MethodInjectAttribute), true)).ToList();
            foreach (var method in oMethods)
            {
                //得到该方法的所有参数实例
                var methodParaInstances = GetObjectInstanceParams(method.GetParameters(), key, oType, method.Name);
                method.Invoke(oInstance, methodParaInstances);
            }
            #endregion

            //注册单例实例时，全局保存实例对象
            if (oRegModel.Lifetime == ServiceLifetime.Singleton)
            {
                oRegModel.SingletonObject = oInstance;
            }
            //注册容器单例实例时，全局保存实例对象
            if (oRegModel.Lifetime == ServiceLifetime.Scoped)
            {
                _scopeDict[key] = oInstance;
            }
            return oInstance;
        }

        /// <summary>
        /// 得到 TForm 全命名空间名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTFormName(Type type, Type toType)
        {
            var key = $"{type.FullName}_$$_";
            if (toType == null)
            {
                var toFullName = _containerDict.Keys.FirstOrDefault(p => p.Contains(key));
                return HasValue(toFullName) ? toFullName : type.FullName;
            }
            return $"{key}{toType.FullName}";
        }

        /// <summary>
        /// 单接口多实现时得到注入的特定服务实例类型
        /// </summary>
        /// <returns></returns>
        private Type GetAliasType(ICustomAttributeProvider provider)
        {
            var paramAliasAttr = provider.GetCustomAttributes(typeof(ParameterAliasInjectAttribute), true).FirstOrDefault();
            if (paramAliasAttr is ParameterAliasInjectAttribute aliasAttr)
                return aliasAttr.AliasType;
            return null;
        }

        /// <summary>
        /// 得到对象实例的参数实例列表
        /// </summary>
        /// <param name="objParams">对象实例的参数列表</param>
        /// <param name="key">字典 key</param>
        /// <param name="oType">对象实例类型</param>
        /// <param name="methodName">方法名称(用于日记记录，只在方法注入时传入)</param>
        /// <returns>参数实例列表</returns>
        private object[] GetObjectInstanceParams(ParameterInfo[] objParams, string key, Type oType, string methodName = null)
        {
            //保存所有的参数实例
            List<object> paramInstances = new List<object>();

            //得到参数的常量值
            object[] constParams = null;
            //判断参数中是否包含常量参数
            var paraConstCount = objParams.Count(p => p.IsDefined(typeof(ParameterConstInjectAttribute), true));
            if (paraConstCount > 0)
            {
                string message = $"{(HasValue(methodName) ? "方法" : "构造函数")}注入{oType.FullName}服务时";
                if (!_constParamDict.ContainsKey(key))
                    throw new Exception($"{message}未传入常量值");
                //得到服务注册时传入的常量值
                constParams = _constParamDict[key];
                if (constParams == null || constParams.Length < 1)
                    throw new Exception($"{message}未传入常量值");
                if (constParams.Length < paraConstCount)
                    throw new Exception($"{message}常量值个数传入不对");
            }
            foreach (var ctorPara in objParams)
            {
                Console.WriteLine($"{oType.FullName}{(HasValue(methodName) ? $" 方法{methodName}" : "")} 注入{ctorPara.ParameterType.Name}参数");
                //当前参数是否是常量参数
                var paraConstAttr = ctorPara.GetCustomAttribute(typeof(ParameterConstInjectAttribute), true);
                if (paraConstAttr is ParameterConstInjectAttribute paramConst)
                    paramInstances.Add(constParams[paramConst.Index]);
                else
                {
                    //当前参数是否指定别名(单接口多实现时注入特定的服务实例)
                    var aliasType = GetAliasType(ctorPara);
                    //得到方法参数实例
                    var paraInstance = CreateInstance(ctorPara.ParameterType, aliasType);
                    paramInstances.Add(paraInstance);
                }
            }
            return paramInstances.ToArray();
        }

        /// <summary>
        /// 是否有值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool HasValue(string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }


    }
}
