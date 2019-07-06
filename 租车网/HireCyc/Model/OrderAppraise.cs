using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 订单评价表
    /// </summary>
    public class OrderAppraise
    {
        public OrderAppraise()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 订单评价表编号
        /// </summary>
        public int OrderappraiseId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderappraiseBowId { get; set; }

        /// <summary>
        /// 对自行车的评分
        /// </summary>
        public int OrderappraiseCycPf { get; set; }

        /// <summary>
        /// 对自行车的评价内容
        /// </summary>
        public string OrderappraiseCycContent { get; set; }

        /// <summary>
        /// 对雇员的评分（5分制）
        /// </summary>
        public int OrderappraiseEmpPf { get; set; }

        /// <summary>
        /// 对雇员的评价内容
        /// </summary>
        public string OrderappraiseEmpCont{ get; set; }

        /// <summary>
        /// 该评价的创建时间
        /// </summary>
        public DateTime OrderappraiseSetTime { get; set; }
    }
}
