using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace MicroserviceDemo.Infrastructure.Util
{
    /// <summary>
    /// Consul 帮助类
    /// </summary>
    public class ConsulHelper
    {
        /// <summary>
        /// 得到服务地址
        /// </summary>
        /// <param name="serveName">服务名称</param>
        /// <returns></returns>
        public static string GetServiceAddress(string serveName)
        {
            var client = new ConsulClient(conf =>
            {
                conf.Address = new Uri("http://127.0.0.1:8500");
                conf.Datacenter = "dc1";
            });
            //得到 Consul 中所有的服务
            var allConsulService = client.Agent.Services().Result.Response;
            var assignServices = allConsulService.Values.Where(p => p.Service.Equals(serveName, StringComparison.OrdinalIgnoreCase)).ToList();
            //foreach (var serve in assignServices)
            //{
            //    Console.WriteLine($"{serve.ID}:{serve.Port}");
            //}

            var invokeService = assignServices.First();

            var url = $"http://{invokeService.Address}:{invokeService.Port}/api/UserService/Message";
            return url;
        }

        /// <summary>
        /// 注册 Consul 服务
        /// </summary>
        public static void RegistConsulService(IConfiguration config, string serviceName)
        {
            var client = new ConsulClient(conf =>
            {
                conf.Address = new Uri("http://127.0.0.1:8500");
                conf.Datacenter = "dc1";
            });
            //得到服务注册地址
            string ip = config["ip"];
            int port = Convert.ToInt32(config["port"]);

            client.Agent.ServiceRegister(new AgentServiceRegistration
            {
                Address = ip,
                Port = port,
                ID = $"{serviceName}_{Guid.NewGuid():N}",
                Name = serviceName,
                //健康检查
                Check = new AgentServiceCheck
                {
                    HTTP = $"http://{ip}:{port}/api/Health",
                    Interval = TimeSpan.FromSeconds(12),
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(60),
                },
            });
        }

    }
}
