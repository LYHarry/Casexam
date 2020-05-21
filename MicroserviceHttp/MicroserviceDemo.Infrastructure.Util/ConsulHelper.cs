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
        private static int _randSeed = 0;

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

            AgentService invokeService = null;
            //取第一个服务
            //invokeService = assignServices.First();

            #region 负载均衡策略

            var rnd = new Random((++_randSeed) + DateTime.Now.Millisecond);

            //1、平均策略(随机策略)
            invokeService = assignServices.ElementAt(rnd.Next(0, assignServices.Count));
            //2、轮询策略
            //invokeService = assignServices.ElementAt(_randSeed++ % assignServices.Count);
            //3、权重策略
            //List<AgentService> weightServices = new List<AgentService>();
            //foreach (var item in assignServices)
            //{
            //    int weight = 1;
            //    if (item.Meta != null && item.Meta.ContainsKey("weight"))
            //        weight = Convert.ToInt32(item.Meta["weight"]);
            //    for (int i = 0; i < weight; i++)
            //    {
            //        weightServices.Add(item);
            //    }
            //}
            //invokeService = weightServices.ElementAt(rnd.Next(0, weightServices.Count));

            #endregion

            return $"http://{invokeService.Address}:{invokeService.Port}";
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
                    //间隔时间
                    Interval = TimeSpan.FromSeconds(12),
                    //检测等待时间
                    Timeout = TimeSpan.FromSeconds(5),
                    //失败后多久移除服务
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(60),
                },
                //自定义属性
                Meta = new Dictionary<string, string>()
                {
                    {  "weight",GetServiceWeight(config["weight"])},
                },
            });
        }

        /// <summary>
        /// 得到服务权重
        /// </summary>
        /// <param name="weight">权重</param>
        /// <returns></returns>
        private static string GetServiceWeight(string weight)
        {
            if (string.IsNullOrWhiteSpace(weight))
                return "1";
            if (int.TryParse(weight, out _))
                return weight;
            return "1";
        }

    }
}
