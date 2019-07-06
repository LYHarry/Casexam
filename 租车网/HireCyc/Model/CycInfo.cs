using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 车辆信息表
    /// </summary>
    public class CycInfo
    {
        public CycInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 车辆信息表编号
        /// </summary>
        public int CycId { get; set; }

        /// <summary>
        /// 车辆名称
        /// </summary>
        public string CycName { get; set; }

        /// <summary>
        /// 车辆类型名称
        /// </summary>
        public string CycType { get; set; }

        /// <summary>
        /// 车辆的租用次数
        /// </summary>
        public int CycBowrrowSun { get; set; }

        /// <summary>
        /// 车辆的购买时间
        /// </summary>
        public DateTime CycBuyTime { get; set; }

        /// <summary>
        /// 车辆修理次数
        /// </summary>
        public int CycRepair { get; set; }

        /// <summary>
        /// 车辆购买金额
        /// </summary>
        public float CycMoney { get; set; }

    }
}
