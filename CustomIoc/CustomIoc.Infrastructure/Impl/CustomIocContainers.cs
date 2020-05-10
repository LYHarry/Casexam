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
        private readonly Dictionary<string, Type> _containerDict = new Dictionary<string, Type>();

        /// <summary>
        /// 常量参数集合字典
        /// </summary>
        private readonly Dictionary<string, object[]> _constParamDict = new Dictionary<string, object[]>();

        /// <summary>
        /// CustomIocContainers 容器构造函数
        /// </summary>
        public CustomIocContainers()
        {
            Console.WriteLine("CustomIocContainers.Constructor");
        }


        /// <summary>
        /// 注册服务
        /// </summary>
        public void Register<TForm, TTo>(params object[] constParams)
            where TForm : class where TTo : TForm
        {
            var key = GetTFormName(typeof(TForm), typeof(TTo));
            _containerDict.Add(key, typeof(TTo));
            if (constParams != null && constParams.Length > 0)
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

            var oType = _containerDict[key];
            //保存构造函数参数实例
            List<object> ctorParaInstance = new List<object>();

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

            //得到构造函数参数
            var ctorParams = assignCtor.GetParameters();
            //得到参数的常量值
            var constParams = GetParamConstValue(ctorParams, key, oType, "构造函数");
            foreach (var ctorPara in ctorParams)
            {
                //当前参数是否是常量
                var ctorParaConstAttr = ctorPara.GetCustomAttribute(typeof(ParameterConstInjectAttribute), true);
                if (ctorParaConstAttr is ParameterConstInjectAttribute paramConstAttr)
                    ctorParaInstance.Add(constParams[paramConstAttr.Index]);
                else
                {
                    //得到构造函数参数实例
                    var paraInstance = CreateInstance(ctorPara.ParameterType);
                    ctorParaInstance.Add(paraInstance);
                }
            }
            #endregion

            //创建实例
            var oInstance = Activator.CreateInstance(oType, ctorParaInstance.ToArray());

            #region 属性注入
            //得到标记了 属性注入特性 的公共属性
            var oProps = oType.GetProperties().Where(p => p.IsDefined(typeof(PropertyInjectAttribute), true)).ToList();
            foreach (var prop in oProps)
            {
                Console.WriteLine($"{oType.FullName} 属性 {prop.Name} 注入 {prop.PropertyType.Name}");
                //得到属性实例
                var propInstance = CreateInstance(prop.PropertyType);
                prop.SetValue(oInstance, propInstance);
            }
            #endregion

            #region 方法注入
            //得到标记了 方法注入特性 的公共方法
            var oMethods = oType.GetMethods().Where(p => p.IsDefined(typeof(MethodInjectAttribute), true)).ToList();
            foreach (var method in oMethods)
            {
                //保存所有的方法参数实例
                List<object> methodParaInstance = new List<object>();
                //得到该方法的所有参数
                var methodParams = method.GetParameters();
                //得到参数的常量值            
                constParams = GetParamConstValue(methodParams, key, oType, "方法");

                foreach (var methodPara in methodParams)
                {
                    Console.WriteLine($"{oType.FullName} 方法 {method.Name} 注入 {methodPara.ParameterType.Name}");
                    //当前参数是否是常量
                    var methodParaConstAttr = methodPara.GetCustomAttribute(typeof(ParameterConstInjectAttribute), true);
                    if (methodParaConstAttr is ParameterConstInjectAttribute paramConstAttr)
                        methodParaInstance.Add(constParams[paramConstAttr.Index]);
                    else
                    {
                        //得到方法参数实例
                        var paraInstance = CreateInstance(methodPara.ParameterType);
                        methodParaInstance.Add(paraInstance);
                    }
                }
                method.Invoke(oInstance, methodParaInstance.ToArray());
            }
            #endregion

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
                return string.IsNullOrWhiteSpace(toFullName) ? type.FullName : toFullName;
            }
            return $"{key}{toType.FullName}";
        }

        /// <summary>
        /// 得到参数的常量值
        /// </summary>
        /// <param name="paras">参数列表</param>
        /// <param name="key">字典 key</param>
        /// <param name="oType">实例类型</param>
        /// <param name="paramType">参数所属类型</param>
        /// <returns></returns>
        private object[] GetParamConstValue(ParameterInfo[] paras, string key, Type oType, string paramType)
        {
            object[] constParams = null;
            //判断参数中是否包含常量参数
            var paraConstCount = paras.Count(p => p.IsDefined(typeof(ParameterConstInjectAttribute), true));
            if (paraConstCount < 1)
                return constParams;

            string message = $"{paramType}注入{oType.FullName}服务时";
            if (!_constParamDict.ContainsKey(key))
                throw new Exception($"{message}未传入常量值");

            constParams = _constParamDict[key];
            if (constParams == null || constParams.Length < 1)
                throw new Exception($"{message}未传入常量值");
            if (constParams.Length < paraConstCount)
                throw new Exception($"{message}常量值个数传入不对");

            return constParams;
        }
    }
}
