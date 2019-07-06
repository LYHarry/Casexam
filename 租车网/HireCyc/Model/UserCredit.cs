using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户信用表
    /// </summary>
    public class UserCredit
    {
        public UserCredit()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 用户信用表编号
        /// </summary>
        public int UserCreditId { get; set; }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserCreditBorrowerBarcode { get; set; }

        /// <summary>
        /// 推迟取车次数
        /// </summary>
        public int UserCreditLatePicklTimes { get; set; }

        /// <summary>
        /// 不取车次数
        /// </summary>
        public int UserCreditCancelPickTimes { get; set; }

        /// <summary>
        /// 推迟还车次数
        /// </summary>
        public int UserCreditDeferReTimes { get; set; }

        /// <summary>
        /// 毁坏车辆次数
        /// </summary>
        public int UserCreditBreakCycTimes { get; set; }

        /// <summary>
        /// 不还车次数
        /// </summary>
        public int UserCreditNotReplaceTimes { get; set; }

        /// <summary>
        /// 总租车次数
        /// </summary>
        public int UserCreditAllTimes { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        public string UserCreditCreditGrade { get; set; }

    }
}
