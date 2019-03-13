using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rpc.Infrastructures.Server;
using Rpc.Repository;
using Rpc.Repository.Interface;
using Rpc.Server.Interface;
using System;
using System.IO;
using System.Reflection;

namespace Rpc.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // 注册服务
            StartupServiceHelper.StartupAsync(null, (services, configuration) =>
            {
                // 注入 Service 服务
                services.AddServices(typeof(Program).Assembly, typeof(IBaseService).Assembly, typeof(IService), "Service");
                // 注入 Repository 仓储
                services.AddServices(typeof(DbService).Assembly, typeof(IDbService).Assembly, typeof(IDbService), "Repository");

            }).GetAwaiter().GetResult();

            Console.Title = "BaseServer";
            Console.ReadKey();
        }
    }
}
