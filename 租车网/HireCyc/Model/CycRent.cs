using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 车辆租用表
    /// </summary>
    public class CycRent
    {
        public CycRent()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 车辆租用表编号
        /// </summary>
        public int CycRentId { get; set; }

        /// <summary>
        /// 车辆名称
        /// </summary>
        public string CycRentCycName { get; set; }

        /// <summary>
        /// 车辆类型名称
        /// </summary>
        public string CycRentCycType { get; set; }

        /// <summary>
        /// 实际取车的时间
        /// </summary>
        public DateTime CycRentRealityBorrowTime { get; set; }

        /// <summary>
        /// 实际还车的时间
        /// </summary>
        public DateTime CycRentRealityReturnTime { get; set; }

        /// <summary>
        /// 车辆毁坏情况编号
        /// </summary>
        public int CycRentCycDam { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int CycRentBorrowId { get; set; }

        /// <summary>
        /// 预定取车的时间
        /// </summary>
        public DateTime CycRentTime { get; set; }

        /// <summary>
        /// 预定还车的时间
        /// </summary>
        public DateTime CycRentReturnTime { get; set; }

        /// <summary>
        /// 租金
        /// </summary>
        public float CycRentMoney { get; set; }




    }
}
