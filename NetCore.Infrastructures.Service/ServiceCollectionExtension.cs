using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NetCore.Infrastructures.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetCore.Infrastructures.Service
{
    /// <summary>
    /// IServiceCollection 扩展类
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册数据库服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbService(this IServiceCollection services, IConfiguration configuration)
        {
            // 注入 数据库连接项
            var dbConnOption = configuration.GetSection("DbConnectionOptions").Get<DbConnectionOptions>();
            services.AddSingleton(Options.Create(dbConnOption));
            // 注入 UnitOfWork 工作单元
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // 注入 DbContext 数据库上下文
            services.AddScoped<IDbContext, DbContext>();
            return services;
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">服务容器</param>
        /// <param name="implAssembly">实现类程序集</param>
        /// <param name="interfaceAssembly">接口程序集</param>
        /// <param name="interfaceType">基类接口类型</param>
        /// <param name="containsName">服务包含的名称</param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services, Assembly implAssembly, Assembly interfaceAssembly, Type interfaceType, string containsName)
        {
            var serviceTypes = interfaceAssembly.GetTypes()
                                                .Where(x => x.IsInterface
                                                            && !x.GetTypeInfo().IsGenericType
                                                            && x != interfaceType)
                                                 .ToList();
            var serviceImplTypes = implAssembly.GetTypes()
                                               .Where(x => x.GetInterfaces().Contains(interfaceType)
                                                           && !x.IsInterface
                                                           && x.Name.EndsWith(containsName))
                                               .ToList();
            foreach (var serviceType in serviceTypes)
            {
                var serviceImplType = serviceImplTypes.FirstOrDefault(x =>
                {
                    if (x.Name == serviceType.Name.Substring(1) &&
                        x.GetTypeInfo().GetInterfaces().Any(n => n.Name == serviceType.Name))
                    {
                        var typeInfo = x.GetTypeInfo();
                        return typeInfo.IsClass && !typeInfo.IsAbstract && !typeInfo.IsGenericType;
                    }
                    return false;
                });
                if (serviceImplType != null)
                    services.AddScoped(serviceType, serviceImplType);
            }
            return services;
        }
    }
}
