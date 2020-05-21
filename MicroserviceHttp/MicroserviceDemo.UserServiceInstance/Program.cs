using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MicroserviceDemo.UserServiceInstance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddCommandLine(args).Build();

            string port = config["port"];
            Console.Title = $"UserService:{port}";
            CreateHostBuilder(args, config["ip"], port).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args, string ip, string port) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://{ip}:{port}");
                });

    }
}
