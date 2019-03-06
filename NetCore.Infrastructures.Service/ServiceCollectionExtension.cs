using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Infrastructures.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetCore.Infrastructures.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbService(this IServiceCollection services, IConfiguration configuration)
        {
            // 注入 数据库连接项
            services.AddSingleton(
                JsonConvert.DeserializeObject<DbConnectionOptions>(configuration.GetSection("ConnectionOptions").Value)
                );
            // 注入 UnitOfWork 工作单元
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // 注入 DbContext 数据库上下文
            services.AddScoped<IDbContext, DbContext>();
            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection serviceBuilder, Assembly implAssembly, Assembly interfaceAssembly, Type interfaceType, string containsName)
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
                    serviceBuilder.AddScoped(serviceType, serviceImplType);
            }

            return serviceBuilder;
        }
    }
}
