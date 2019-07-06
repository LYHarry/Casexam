using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 信用等级表
    /// </summary>
    public class CreditGrade
    {
        public CreditGrade()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 信用等级表编号
        /// </summary>
        public int CreditGradeId { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        public string CreditGradeGrade { get; set; }

        /// <summary>
        /// 可租用车数量
        /// </summary>
        public int CreditGradeBorrowCount { get; set; }

        /// <summary>
        /// 打折比率
        /// </summary>
        public float CreditGradeDiscount { get; set; }
    }
}
