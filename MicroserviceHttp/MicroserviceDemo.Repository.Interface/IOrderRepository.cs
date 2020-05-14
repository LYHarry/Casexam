using MicroserviceDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.Repository.Interface
{
    public interface IOrderRepository
    {
        OrderEntity GetOrderInfo(int id);

        List<OrderEntity> GetAllOrders();

    }
}
