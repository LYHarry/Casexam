using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 订单评价表DAL
    /// </summary>
    public class OrderAppraiseDataAccess
    {
        /// <summary>
        /// 添加订单评价表信息
        /// </summary>
        /// <param name="orderAppraise"></param>
        /// <returns></returns>
        public static bool OrderAppraiseAdd(Model.OrderAppraise orderAppraise)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@BowId",orderAppraise.OrderappraiseBowId),
                new SqlParameter("@CycPf",orderAppraise.OrderappraiseCycPf),
                new SqlParameter("@CycContent",orderAppraise.OrderappraiseCycContent),
                new SqlParameter("@EmpPf",orderAppraise.OrderappraiseEmpPf),
                new SqlParameter("@EmpCont",orderAppraise.OrderappraiseEmpCont)  
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("OrderAppraiseAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据订单的编号删除数据
        /// </summary>
        /// <param name="OrderappraiseBowId"></param>
        /// <returns></returns>
        public static bool OrderAppraiseDel(int OrderappraiseBowId)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@BowId",OrderappraiseBowId)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("OrderAppraiseDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据订单表编号查询订单的评价内容
        /// </summary>
        /// <param name="OrderappraiseBowId"></param>
        /// <returns></returns>
        public static List<Model.OrderAppraise> orderAppraise(int OrderappraiseBowId)
        {
            List<Model.OrderAppraise> list = new List<Model.OrderAppraise>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@id",OrderappraiseBowId)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("OrderAppraiseLookByBid", CommandType.StoredProcedure, p);

            while (sdr.Read())
            {

                Model.OrderAppraise orderAppraise = new Model.OrderAppraise();//创建一个对象

                orderAppraise.OrderappraiseBowId = Convert.ToInt32(sdr["订单编号"]);
                orderAppraise.OrderappraiseCycPf = Convert.ToInt32(sdr["自行车评分"]);
                orderAppraise.OrderappraiseCycContent = Convert.ToString(sdr["自行车评价"]);
                orderAppraise.OrderappraiseEmpPf = Convert.ToInt32(sdr["员工评分"]);
                orderAppraise.OrderappraiseEmpCont = Convert.ToString(sdr["员工评价"]);
                orderAppraise.OrderappraiseSetTime = Convert.ToDateTime(sdr["评价创建时间"]);
               
                list.Add(orderAppraise);
            }
            return list;
        }

        /// <summary>
        /// 查询所有的订单评价表内容
        /// </summary>
        /// <returns></returns>
        public static List<Model.OrderAppraise> OrderAppraiseLookAll()
        {
            List<Model.OrderAppraise> list = new List<Model.OrderAppraise>();

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("OrderAppraiseLookAll", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.OrderAppraise orderAppraise = new Model.OrderAppraise();

                orderAppraise.OrderappraiseId = Convert.ToInt32(sdr["表编号"]);
                orderAppraise.OrderappraiseBowId = Convert.ToInt32(sdr["订单编号"]);
                orderAppraise.OrderappraiseCycPf = Convert.ToInt32(sdr["自行车评分"]);
                orderAppraise.OrderappraiseCycContent = Convert.ToString(sdr["自行车评价"]);
                orderAppraise.OrderappraiseEmpPf = Convert.ToInt32(sdr["员工评分"]);
                orderAppraise.OrderappraiseEmpCont = Convert.ToString(sdr["员工评价"]);
                orderAppraise.OrderappraiseSetTime = Convert.ToDateTime(sdr["评价创建时间"]);

                list.Add(orderAppraise);
            }
            return list;
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.OrderAppraise> OrderAppraiseFeny(int ys, int count)
        {
            List<Model.OrderAppraise> list = new List<Model.OrderAppraise>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@ys",ys),
              new SqlParameter("@count",count) 
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("OrderAppraiseFeny", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.OrderAppraise orderAppraise = new Model.OrderAppraise();
                orderAppraise.OrderappraiseId = Convert.ToInt32(sdr["编号"]);
                orderAppraise.OrderappraiseBowId = Convert.ToInt32(sdr["订单编号"]);
                orderAppraise.OrderappraiseCycPf = Convert.ToInt32(sdr["自行车评分"]);
                orderAppraise.OrderappraiseCycContent = Convert.ToString(sdr["自行车评价"]);
                orderAppraise.OrderappraiseEmpPf = Convert.ToInt32(sdr["员工评分"]);
                orderAppraise.OrderappraiseEmpCont = Convert.ToString(sdr["员工评价"]);
                orderAppraise.OrderappraiseSetTime = Convert.ToDateTime(sdr["评价创建时间"]);

                list.Add(orderAppraise);
            }
            return list;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int OrderAppraiseYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@count",count)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("OrderAppraiseYs", CommandType.StoredProcedure, p));
            return i;
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool OrderAppLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("OrderAppLookID", CommandType.StoredProcedure, p));

            return f == 1;   //为真表示存在
        }
    }
}
