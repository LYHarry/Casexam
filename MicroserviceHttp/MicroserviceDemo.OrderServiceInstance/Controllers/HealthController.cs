using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceDemo.OrderServiceInstance.Controllers
{
    [Route("api/Health")]
    public class HealthController : Controller
    {
        private readonly IConfiguration _config;

        public HealthController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine($"OrderService:{_config["port"]} 健康检查 {DateTime.Now:yyyy-MM-dd HH:mm:ss fff}");
            return Ok();
        }
    }
}
