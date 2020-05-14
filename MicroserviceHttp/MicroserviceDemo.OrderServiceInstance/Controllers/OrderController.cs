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
    }
}
