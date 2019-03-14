using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rpc.Infrastructures.Server.RPC;
using Rpc.Protocols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Server
{
    /// <summary>
    /// 启动服务帮助类
    /// </summary>
    public class StartupServiceHelper
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> StartupAsync(Assembly assembly, Action<IServiceCollection, IConfigurationRoot> action)
        {
            // Configuration对象，并添加 appsettings.json 配置文件
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            var configuration = configurationBuilder.Build();

            // 创建 ServiceCollection
            IServiceCollection services = new ServiceCollection();
            services.AddOptions();
            // 注入 数据库上下文
            services.AddDbService(configuration);
            //回调方法
            action(services, configuration);

            var serviceResolver = services.ToServiceContainer().Build();

            Console.WriteLine("-----------------------Servie Starting-----------------------");
            // 得到此服务的地址和端口
            var serviceSiteOpt = configuration.GetSection("ServiceSiteOption").Get<ServiceSiteOption>();
            Console.WriteLine($"{Console.Title} 服务地址为: {serviceSiteOpt.IP}:{serviceSiteOpt.Port}");
            var list = GetServiceALLMethod(assembly); //得到此服务下的所有可执行方法
            var server = new Grpc.Core.Server
            {
                Services = { CallRpcService.BindService(new CallRpcServiceImpl(serviceResolver, list)) },
                Ports = { new ServerPort(serviceSiteOpt.IP, serviceSiteOpt.Port, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.WriteLine("-----------------------Servie Started Success-----------------------");

            return await Task.FromResult(true);
        }

        /// <summary>
        /// 得到此服务下所有的执行方法
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static List<ServiceMethodOption> GetServiceALLMethod(Assembly assembly)
        {
            var allServiceMethod = new List<ServiceMethodOption>();
            var serviceTypes = assembly.GetTypes()
                                       .Where(x => x.GetInterfaces().Contains(typeof(IService))
                                                   && !x.IsInterface
                                                   && !x.IsAbstract
                                                   && x.Name.Contains("Service"))
                                       .ToList();
            List<MethodInfo> methods;
            foreach (var item in serviceTypes)
            {
                methods = item.GetMethods().Where(x => x.IsPublic && x.DeclaringType != typeof(object)).ToList();
                foreach (var method in methods)
                {
                    // 得到方法的请求参数
                    var requestType = method.GetParameters().FirstOrDefault()?.ParameterType;
                    // 得到方法的返回结果参数
                    var retParamType = method.ReturnParameter.ParameterType;
                    var reponseProp = retParamType.GetMember("Result").FirstOrDefault() as PropertyInfo;
                    var reponseType = reponseProp?.PropertyType;
                    if (reponseType == null)
                        throw new Exception($"{item.Namespace}.{method.Name}返回参数不能为空.");

                    allServiceMethod.Add(new ServiceMethodOption
                    {
                        MethodName = method.Name,
                        ServiceType = item,
                        RepType = reponseType,
                        ReqType = requestType,
                        Namespace = item.FullName
                    });
                }
            }
            return allServiceMethod;
        }
    }
}
