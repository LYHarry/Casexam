using Rpc.Infrastructures.Server;
using Rpc.Repository;
using Rpc.Repository.Interface;
using Rpc.UserServer.Interface;
using System;

namespace Rpc.UserServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 注册服务
            StartupServiceHelper.StartupAsync(null, (services, configuration) =>
            {
                // 注入 Service 服务
                services.AddServices(typeof(Program).Assembly, typeof(IUserService).Assembly, typeof(IService), "Service");
                // 注入 Repository 仓储
                services.AddServices(typeof(DbService).Assembly, typeof(IDbService).Assembly, typeof(IDbService), "Repository");

            }).GetAwaiter().GetResult();

            Console.Title = "UserServer";
            Console.ReadKey();
        }
    }
}
