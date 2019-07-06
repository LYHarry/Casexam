using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 客户反馈表
    /// </summary>
    public class FeedbackDataAccess
    {
        /// <summary>
        /// 添加客户反馈表数据
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public static bool FeedbackAdd(Model.Feedback feedback)
        {
            SqlParameter[] p = new SqlParameter[]
           {
                new SqlParameter("@Theme",feedback.FeedbackTheme),
                new SqlParameter("@Content",feedback.FeedbackContent),
                new SqlParameter("@Tel",feedback.FeedbackTel)
           };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("FeedbackAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据ID删除客户反馈表数据
        /// </summary>
        /// <param name="FeedbackId"></param>
        /// <returns></returns>
        public static bool FeedbackDel(int FeedbackId)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",FeedbackId)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("FeedbackDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据主题查询反馈表数据
        /// </summary>
        /// <param name="FeedbackTheme"></param>
        /// <returns></returns>
        public static List<Model.Feedback> FeedbackLookByTheme(string FeedbackTheme)
        {
            List<Model.Feedback> list = new List<Model.Feedback>();

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Theme",FeedbackTheme)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("FeedbackLookByTheme", CommandType.StoredProcedure, p);

            while (dr.Read())
            {
                Model.Feedback feedback = new Model.Feedback();
                feedback.FeedbackId = Convert.ToInt32(dr["表编号"]);
                feedback.FeedbackTheme = dr["主题"].ToString();
                feedback.FeedbackContent = dr["内容"].ToString();
                feedback.FeedbackTel = dr["联系方式"].ToString();
                feedback.FeedbackTime = Convert.ToDateTime(dr["创建时间"]);
                list.Add(feedback);
            }
            return list;
        }

        /// <summary>
        /// 查询所有反馈数据
        /// </summary>
        /// <returns></returns>
        public static List<Model.Feedback> FeedbackLookAll()
        {
            List<Model.Feedback> list = new List<Model.Feedback>();

            SqlDataReader dr = SQLHelper.ExecuteDataReader("FeedbackLookAll", CommandType.StoredProcedure);

            while (dr.Read())
            {
                Model.Feedback feedback = new Model.Feedback();

                feedback.FeedbackId = Convert.ToInt32(dr["表编号"]);
                feedback.FeedbackTheme = dr["主题"].ToString();
                feedback.FeedbackContent = dr["内容"].ToString();
                feedback.FeedbackTel = dr["联系方式"].ToString();
                feedback.FeedbackTime = Convert.ToDateTime(dr["创建时间"]);
                list.Add(feedback);
            }
            return list;
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool FeekbackLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
            };

            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("FeedbackLookID", CommandType.StoredProcedure, p));
            return f == 1;
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.Feedback> FeedbackFeny(int ys, int count)
        {
            List<Model.Feedback> list = new List<Model.Feedback>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@ys",ys),
              new SqlParameter("@count",count)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("FeedbackFeny", CommandType.StoredProcedure, p);
            while (dr.Read())
            {
                Model.Feedback feedback = new Model.Feedback();
                feedback.FeedbackId = Convert.ToInt32(dr["主题"]);
                feedback.FeedbackTheme = dr["主题"].ToString();
                feedback.FeedbackContent = dr["内容"].ToString();
                feedback.FeedbackTel = dr["联系方式"].ToString();
                feedback.FeedbackTime = Convert.ToDateTime(dr["创建时间"]);
                list.Add(feedback);
            }
            return list;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int FeedbackYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@count",count)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("FeedbackYs", CommandType.StoredProcedure, p));
            return i;
        }
    }
}
