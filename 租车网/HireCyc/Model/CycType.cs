using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 车辆类型表
    /// </summary>
    public class CycType
    {
        public CycType()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 车辆类型表编号
        /// </summary>
        public int CycTypeId { get; set; }

        /// <summary>
        /// 车辆类型名称
        /// </summary>
        public string CycTypeName { get; set; }

        /// <summary>
        /// 车辆的库存
        /// </summary>
        public int CycTypeStock { get; set; }

        /// <summary>
        /// 车辆的押金
        /// </summary>
        public float CycTypeHire { get; set; }

        /// <summary>
        /// 车辆租金（小时）
        /// </summary>
        public float CycTypeLagHrMoney { get; set; }

        /// <summary>
        /// 车辆租金（天)
        /// </summary>
        public float CycTypeLagDayMoney { get; set; }

        /// <summary>
        /// 车辆迟还时的租金（小时）
        /// </summary>
        public float CycTypeLateHrMoney { get; set; }

        /// <summary>
        /// 车辆迟还时的租金（天）
        /// </summary>
        public float CycTypeLateDayMoney { get; set; }

  
    }
}
