using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 客户反馈表BLL
    /// </summary>
   public class FeedbackBusiness
    {
        /// <summary>
        /// 添加客户反馈表数据
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public static bool FeedbackAdd(Model.Feedback feedback)
        {
            return DAL.FeedbackDataAccess.FeedbackAdd(feedback);
        }

        /// <summary>
        /// 根据ID删除客户反馈表数据
        /// </summary>
        /// <param name="FeedbackId"></param>
        /// <returns></returns>
        public static bool FeedbackDel(int FeedbackId)
        {
            return DAL.FeedbackDataAccess.FeedbackDel(FeedbackId);
        }

        /// <summary>
        /// 根据主题查询反馈表数据
        /// </summary>
        /// <param name="FeedbackTheme"></param>
        /// <returns></returns>
        public static List<Model.Feedback> FeedbackLookByTheme(string FeedbackTheme)
        {
            return DAL.FeedbackDataAccess.FeedbackLookByTheme(FeedbackTheme);
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool FeekbackLookId(int id)
        {
            return DAL.FeedbackDataAccess.FeekbackLookId(id);
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.Feedback> FeedbackFeny(int ys, int count)
        {
            return DAL.FeedbackDataAccess.FeedbackFeny(ys, count);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int FeedbackYs(int count)
        {
            return DAL.FeedbackDataAccess.FeedbackYs(count);
        }

        /// <summary>
        /// 查询所有反馈数据
        /// </summary>
        /// <returns></returns>
        public static List<Model.Feedback> FeedbackLookAll()
        {
            return DAL.FeedbackDataAccess.FeedbackLookAll();
        }
    }
}
