using MicroserviceDemo.Infrastructure.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceDemo.WebApi.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("UserInfo")]
        public string GetUserInfo()
        {
            var url = ConsulHelper.GetServiceAddress("UserService");
            Console.WriteLine($"接口层-开始调用 {url} 服务");

            var res = HttpClientHelper.GetAsync($"{url}/api/UserService/Message");
            return $"接口层-服务响应结果: \r\n {res}";
        }
    }
}
