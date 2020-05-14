using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.Model
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderEntity
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int BookingID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 订单价格
        /// </summary>
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
