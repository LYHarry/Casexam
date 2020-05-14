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
            return "OrderController.GetOrderInfo";
        }
    }
}
