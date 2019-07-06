using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 客户反馈表
    /// </summary>
    public class Feedback
    {
        public Feedback()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 客户反馈表编号
        /// </summary>
        public int FeedbackId { get; set; }

        /// <summary>
        /// 反馈主题
        /// </summary>
        public string FeedbackTheme { get; set; }

        /// <summary>
        /// 反馈内容
        /// </summary>
        public string FeedbackContent { get; set; }

        /// <summary>
        /// 反馈人联系电话
        /// </summary>
        public string FeedbackTel { get; set; }

        /// <summary>
        /// 反馈的时间
        /// </summary>
        public DateTime FeedbackTime { get; set; }
    }
}
