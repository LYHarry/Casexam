using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 订单表DAL
    /// </summary>
    public class CycBorrowDataAccess
    {
        /// <summary>
        /// 添加订单数据
        /// </summary>
        /// <param name="cb">订单对象</param>
        /// <returns></returns>
        public static bool CycBorrowAdd(Model.CycBorrow cb)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@BowCode",cb.CycBorrowBowCode),
                new SqlParameter("@Count",cb.CycBorrowCount)   ,
                new SqlParameter("@empAcc",cb.CycBorrowEmpcode),
                new SqlParameter("@status",cb.CycBorrowStatus)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycBorrowAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据订单编号删除数据
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowDel(int id)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
            new SqlParameter("@id",id)    
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycBorrowDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据用户编号查询总租车次数
        /// </summary>
        /// <param name="code">用户编号</param>
        /// <returns>int值</returns>
        public static int CycBorrowLookAllTime(string code)
        {
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@BowCode",code)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookAllTime", CommandType.StoredProcedure, p));
            return i;
        }

        /// <summary>
        /// 根据订单编号查询该订单内是否有毁坏车辆情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookBreakCycTimes(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BorrowId",id)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookBreakCycTimes", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据用户帐号查询订单数据
        /// </summary>
        /// <param name="BowCode">用户帐号</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookBycode(string BowCode)
        {
            List<Model.CycBorrow> list = new List<Model.CycBorrow>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BowCode",BowCode)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycBorrowLookBycode", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycBorrow cycBorrow = new Model.CycBorrow();

                cycBorrow.CycBorrowId = Convert.ToInt32(sdr["订单表编号"]);
                cycBorrow.CycBorrowCount = Convert.ToInt32(sdr["租车数"]);
                cycBorrow.CycBorrowEmpcode = Convert.ToString(sdr["处理订单的员工编号"]);
                cycBorrow.CycBorrowSetTime = Convert.ToDateTime(sdr["创建时间"]);
                cycBorrow.CycBorrowStatus = Convert.ToString(sdr["订单状态"]);
                cycBorrow.CycBorrowRealMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycBorrow);
            }
            return list;
        }

        /// <summary>
        /// 根据用户帐号查询最新的一条订单数据
        /// </summary>
        /// <param name="BowCode">用户帐号</param>
        /// <returns></returns>
        public static Model.CycBorrow CycBorrowLookNewBycode(string BowCode)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BowCode",BowCode)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycBorrowLookBycode", CommandType.StoredProcedure);

            Model.CycBorrow cycBorrow = new Model.CycBorrow();
            while (sdr.Read())
            {
                cycBorrow.CycBorrowId = Convert.ToInt32(sdr["订单表编号"]);
                cycBorrow.CycBorrowCount = Convert.ToInt32(sdr["租车数"]);
                cycBorrow.CycBorrowEmpcode = Convert.ToString(sdr["处理订单的员工编号"]);
                cycBorrow.CycBorrowSetTime = Convert.ToDateTime(sdr["创建时间"]);
                cycBorrow.CycBorrowStatus = Convert.ToString(sdr["订单状态"]);
                cycBorrow.CycBorrowRealMoney = Convert.ToSingle(sdr["租金"]);
            }

            return cycBorrow;
        }

        /// <summary>
        /// 查询某员工处理的订单
        /// </summary>
        /// <param name="empcode">员工编号</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookByEmpcode(string empcode)
        {
            List<Model.CycBorrow> list = new List<Model.CycBorrow>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Empcode",empcode)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycBorrowLookByEmpcode", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycBorrow cycBorrow = new Model.CycBorrow();

                cycBorrow.CycBorrowId = Convert.ToInt32(sdr["订单编号"]);
                cycBorrow.CycBorrowBowCode = Convert.ToString(sdr["用户帐号"]);
                cycBorrow.CycBorrowCount = Convert.ToInt32(sdr["租车数"]);
                cycBorrow.CycBorrowSetTime = Convert.ToDateTime(sdr["创建时间"]);
                cycBorrow.CycBorrowStatus = Convert.ToString(sdr["订单状态"]);
                cycBorrow.CycBorrowRealMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycBorrow);
            }
            return list;
        }

        /// <summary>
        /// 根据订单状态查询订单信息
        /// </summary>
        /// <param name="status">订单状态</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookByStatus(string status)
        {
            List<Model.CycBorrow> list = new List<Model.CycBorrow>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Status",status)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycBorrowLookByStatus", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CycBorrow cycBorrow = new Model.CycBorrow();
                cycBorrow.CycBorrowBowCode = Convert.ToString(sdr["用户帐号"]);
                cycBorrow.CycBorrowCount = Convert.ToInt32(sdr["租车数"]);
                cycBorrow.CycBorrowEmpcode = Convert.ToString(sdr["处理订单的员工编号"]);
                cycBorrow.CycBorrowSetTime = Convert.ToDateTime(sdr["创建时间"]);
                cycBorrow.CycBorrowStatus = Convert.ToString(sdr["订单状态"]);
                cycBorrow.CycBorrowRealMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycBorrow);
            }
            return list;
        }

        /// <summary>
        /// 根据时间段查询用户的订单
        /// </summary>
        /// <param name="t1">时间段的起始时间</param>
        /// <param name="t2">时间段的结束时间 </param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookByTimeD(DateTime t1, DateTime t2)
        {
            List<Model.CycBorrow> list = new List<Model.CycBorrow>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@time1",t1),
              new SqlParameter("@time2",t2)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycBorrowLookByTimeD", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CycBorrow cycBorrow = new Model.CycBorrow();
                cycBorrow.CycBorrowBowCode = Convert.ToString(sdr["用户帐号"]);
                cycBorrow.CycBorrowCount = Convert.ToInt32(sdr["租车数"]);
                cycBorrow.CycBorrowEmpcode = Convert.ToString(sdr["处理订单的员工编号"]);
                cycBorrow.CycBorrowSetTime = Convert.ToDateTime(sdr["创建时间"]);
                cycBorrow.CycBorrowStatus = Convert.ToString(sdr["订单状态"]);
                cycBorrow.CycBorrowRealMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycBorrow);
            }
            return list;
        }

        /// <summary>
        /// 判断该订单内是否有不取车的情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookCancelPickTimes(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BorrowId",id)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookCancelPickTimes", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 判断该订单中是否有迟还车的情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookDeferReTimes(int id)
        {
            int i = 0;
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BorrowId",id)
            };
            i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookDeferReTimes", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据帐号查找订单编号
        /// </summary>
        /// <param name="BowCode">用户帐号</param>
        /// <returns>list值</returns>
        public static int CycBorrowLookIdBycode(string BowCode)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BowCode",BowCode)
            };

            int CycBorrowId = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookIdBycode", CommandType.StoredProcedure, p));

            return CycBorrowId;
        }

        /// <summary>
        /// 根据订单编号判断是否有推迟取车情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookLatePicklTimes(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BorrowId",id)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookLatePicklTimes", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 判断该订单是否有不还车情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookNotReplaceTimes(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@BorrowId",id)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookNotReplaceTimes", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据订单号修改该辆车的最后租金
        /// </summary>
        /// <param name="id">订单号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowUpdateRealMoney(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Id",id)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycBorrowUpdateRealMoney", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        ///根据订单编号修改订单状态
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowUpdateStatus(int id, string status)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@id",id),
              new SqlParameter("@Status",status)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycBorrowUpdateStatus", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据每页的条数计算出总页数
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值</returns>
        public static int CycBorrowYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@count",count)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowYs", CommandType.StoredProcedure, p));
            return i;
        }

        /// <summary>
        /// **************分页显示*******************8？
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowFeny(int ys, int count)
        {
            List<Model.CycBorrow> list = new List<Model.CycBorrow>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@ys",ys),
                new SqlParameter("@count",count)        
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycBorrowFeny", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CycBorrow cycBorrow = new Model.CycBorrow();
                cycBorrow.CycBorrowId = Convert.ToInt32(sdr["编号"]);
                cycBorrow.CycBorrowBowCode = Convert.ToString(sdr["用户帐号"]);
                cycBorrow.CycBorrowCount = Convert.ToInt32(sdr["租车数"]);
                cycBorrow.CycBorrowEmpcode = Convert.ToString(sdr["处理订单的员工编号"]);
                cycBorrow.CycBorrowSetTime = Convert.ToDateTime(sdr["创建时间"]);
                cycBorrow.CycBorrowStatus = Convert.ToString(sdr["订单状态"]);
                cycBorrow.CycBorrowRealMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycBorrow);
            }
            return list;
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool CycBorrowLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("CycBorrowLookID", CommandType.StoredProcedure, p));

            return f == 1;  //为真表示存在
        }
    }
}
