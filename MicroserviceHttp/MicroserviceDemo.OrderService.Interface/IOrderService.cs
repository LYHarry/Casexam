using MicroserviceDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.OrderService.Interface
{
    public interface IOrderService
    {
        OrderEntity GetOrderInfo(int id);

        List<OrderEntity> GetAllOrders();

    }
}
