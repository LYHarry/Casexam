using MicroserviceDemo.Model;
using MicroserviceDemo.OrderService.Interface;
using MicroserviceDemo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _order;

        public OrderService(IOrderRepository orderRepository)
        {
            _order = orderRepository;
        }

        public OrderEntity GetOrderInfo(int id)
        {
            return _order.GetOrderInfo(id);
        }

        public List<OrderEntity> GetAllOrders()
        {
            return _order.GetAllOrders();
        }
    }
}
