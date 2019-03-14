using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rpc.Infrastructures.Repository;
using System;
using System.Linq;
using System.Reflection;

namespace Rpc.Infrastructures.Server
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbService(this IServiceCollection services, IConfigurationRoot configuration)
        {
            // 注入 数据库连接项
            var dbConnOptions = configuration.GetSection("DbConnectionOptions").Get<DbConnectionOptions>();
            services.AddSingleton(Options.Create(dbConnOptions));
            // 注入 UnitOfWork 工作单元
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // 注入 DbContext 数据库上下文
            services.AddScoped<IDbContext, DbContext>();
            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services, Assembly implAssembly, Assembly interfaceAssembly, Type interfaceType, string containsName)
        {
            var serviceTypes = interfaceAssembly.GetTypes()
                .Where(x => x.IsInterface && !x.GetTypeInfo().IsGenericType && x != interfaceType).ToList();
            var serviceImplTypes = implAssembly.GetTypes().Where(x =>
                x.GetInterfaces().Contains(interfaceType) && !x.IsInterface && x.Name.EndsWith(containsName)).ToList();

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
