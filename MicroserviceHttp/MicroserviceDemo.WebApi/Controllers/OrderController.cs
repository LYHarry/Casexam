using MicroserviceDemo.Infrastructure.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceDemo.WebApi.Controllers
{
    [Route("api/Order")]
    public class OrderController : Controller
    {
        [HttpGet]
        [Route("OrderInfo")]
        public string GetOrderInfo()
        {
            var url = ConsulHelper.GetServiceAddress("OrderService");
            Console.WriteLine($"接口层-开始调用 {url} 服务");

            var res = HttpClientHelper.GetAsync($"{url}/api/OrderService/Message");
            return $"接口层-服务响应结果: \r\n {res}";
        }



    }
}
