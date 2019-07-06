using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class CycBorrow
    {
        public CycBorrow()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        ///  订单表编号
        /// </summary>
        public int CycBorrowId { get; set; }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string CycBorrowBowCode { get; set; }

        /// <summary>
        /// 租用车辆数
        /// </summary>
        public int CycBorrowCount { get; set; }

        /// <summary>
        /// 处理订单的雇员账号
        /// </summary>
        public string CycBorrowEmpcode { get; set; }

        /// <summary>
        /// 该订单创建的时间
        /// </summary>
        public DateTime CycBorrowSetTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string CycBorrowStatus { get; set; }

        /// <summary>
        /// 实际总计租金
        /// </summary>
        public float CycBorrowRealMoney { get; set; }


    }
}
