using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 账户表，支付情况
    /// </summary>
    public class PayInfo
    {
        public PayInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 账户表编号
        /// </summary>
        public int PayInfoId { get; set; }

        /// <summary>
        /// 用户账号或员工账员
        /// </summary>
        public string PayInfoUserAcc { get; set; }

        /// <summary>
        /// 支付类型，银行卡，支付宝
        /// </summary>
        public string PayInfoType { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string PayInfoCodeAcc { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PayInfoPassw { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public float PayInfoBlackFigure { get; set; }

    }
}
