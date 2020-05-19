using MicroserviceDemo.Model;
using MicroserviceDemo.OrderService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceDemo.OrderServiceInstance.Controllers
{
    [Route("api/OrderService")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("Order")]
        public OrderEntity GetOrderInfo(int id)
        {
            return _orderService.GetOrderInfo(id);
        }

        [HttpGet]
        [Route("AllOrder")]
        public List<OrderEntity> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet("Message")]
        public string GetMessage()
        {
            var msg = $"OrderService: {DateTime.Now:yyyy-MM-dd HH:mm:ss fff}";

            Console.WriteLine(msg);

            return msg;
        }
    }
}
