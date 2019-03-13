using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
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
        public static async Task<bool> StartupAsync(Assembly assembly, Action<IServiceCollection, IConfiguration> action)
        {
            // Configuration对象，并添加 appsettings.json 配置文件
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            var configuration = configurationBuilder.Build();

            // 创建 ServiceCollection
            IServiceCollection services = new ServiceCollection();
            // 注入 数据库上下文
            services.AddDbService(configuration);
            //回调方法
            action(services, configuration);

            return await Task.FromResult(true);
        }
    }
}
