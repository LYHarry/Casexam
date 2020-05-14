using MicroserviceDemo.Model;
using MicroserviceDemo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroserviceDemo.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<OrderEntity> _orderEntities;

        public OrderRepository()
        {
            _orderEntities = new List<OrderEntity>
            {
                new OrderEntity()
                {
                    BookingID = 1,
                    UserID = 1,
                    OrderPrice = 10.52m,
                    CreateDate = DateTime.Now
                },
                new OrderEntity()
                {
                    BookingID = 2,
                    UserID = 1,
                    OrderPrice = 10,
                    CreateDate = DateTime.Now
                },
                new OrderEntity()
                {
                    BookingID = 3,
                    UserID = 1,
                    OrderPrice = 25,
                    CreateDate = DateTime.Now
                },
                new OrderEntity()
                {
                    BookingID = 4,
                    UserID = 1,
                    OrderPrice = 451,
                    CreateDate = DateTime.Now
                },
                new OrderEntity()
                {
                    BookingID = 5,
                    UserID = 1,
                    OrderPrice = 19,
                    CreateDate = DateTime.Now
                }
            };
        }

        public OrderEntity GetOrderInfo(int id)
        {
            return _orderEntities.FirstOrDefault(p => p.BookingID == id);
        }

        public List<OrderEntity> GetAllOrders()
        {
            return _orderEntities;
        }

    }
}
