using Rpc.BaseServer.Interface;
using Rpc.Infrastructures.Server;
using Rpc.Repository;
using Rpc.Repository.Interface;
using System;

namespace Rpc.BaseServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "BaseServer";
            // 注册服务
            StartupServiceHelper.StartupAsync(typeof(Program).Assembly, (services, configuration) =>
            {
                // 注入 Service 服务
                services.AddServices(typeof(Program).Assembly, typeof(IBaseService).Assembly, typeof(IService), "Service");
                // 注入 Repository 仓储
                services.AddServices(typeof(DbService).Assembly, typeof(IDbService).Assembly, typeof(IDbService), "Repository");

            }).GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}
