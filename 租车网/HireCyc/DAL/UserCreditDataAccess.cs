using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 用户信用表DAL
    /// </summary>
    public class UserCreditDataAccess
    {
        /// <summary>
        /// 添加用户等级信息,添加用户帐号
        /// </summary>
        /// <param name="userCredit"></param>
        /// <returns>bool值</returns>
        public static bool UserCreditAdd(string BorrowerBarcode)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@BorrowerBarcode",BorrowerBarcode)              
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserCreditAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据账号删除用户等级表信息
        /// </summary>
        /// <param name="borrowerBarcode">帐号</param>
        /// <returns>bool值</returns>
        public static bool UserCreditDel(string borrowerBarcode)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@BorrowerBarcode",borrowerBarcode)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserCreditDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据用户帐号查询数据
        /// </summary>
        /// <param name="borrowerBarcode">帐号</param>
        /// <returns>list值</returns>
        public static List<Model.UserCredit> UserCreditLookByBorrowerBarcode(string borrowerBarcode)
        {
            List<Model.UserCredit> list = new List<Model.UserCredit>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@BorrowerBarcode",borrowerBarcode)        
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("UserCreditLookByBorrowerBarcode", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.UserCredit userCredit = new Model.UserCredit();

                userCredit.UserCreditLatePicklTimes = Convert.ToInt32(sdr["推迟取车次数"]);
                userCredit.UserCreditCancelPickTimes = Convert.ToInt32(sdr["不取车次数"]);
                userCredit.UserCreditDeferReTimes = Convert.ToInt32(sdr["推迟还车次数"]);
                userCredit.UserCreditBreakCycTimes = Convert.ToInt32(sdr["毁坏车辆次数"]);
                userCredit.UserCreditNotReplaceTimes = Convert.ToInt32(sdr["不还车次数"]);
                userCredit.UserCreditAllTimes = Convert.ToInt32(sdr["总租车次数"]);
                userCredit.UserCreditCreditGrade = Convert.ToString(sdr["信用等级"]);
                list.Add(userCredit);
            }
            return list;
        }

        /// <summary>
        /// *******分页显示*************？
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页条数</param>
        /// <returns>list值</returns>
        public static List<Model.UserCredit> UserCreditFeny(int ys, int count)
        {
            List<Model.UserCredit> list = new List<Model.UserCredit>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@ys",ys),
                new SqlParameter("@count",count)         
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("UserCreditFeny", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.UserCredit userCredit = new Model.UserCredit();

                userCredit.UserCreditId = Convert.ToInt32(sdr["编号"]);
                userCredit.UserCreditBorrowerBarcode = Convert.ToString(sdr["用户编号"]);
                userCredit.UserCreditLatePicklTimes = Convert.ToInt32(sdr["推迟取车次数"]);
                userCredit.UserCreditCancelPickTimes = Convert.ToInt32(sdr["不取车次数"]);
                userCredit.UserCreditDeferReTimes = Convert.ToInt32(sdr["推迟还车次数"]);
                userCredit.UserCreditBreakCycTimes = Convert.ToInt32(sdr["毁坏车辆次数"]);
                userCredit.UserCreditNotReplaceTimes = Convert.ToInt32(sdr["不还车次数"]);
                userCredit.UserCreditAllTimes = Convert.ToInt32(sdr["总租车次数"]);
                userCredit.UserCreditCreditGrade = Convert.ToString(sdr["信用等级"]);
                list.Add(userCredit);
            }
            return list;
        }

        /// <summary>
        /// 根据用户帐号查看信用等级
        /// </summary>
        /// <param name="borrowerBarcode">帐号</param>
        /// <returns>string值，信用等级</returns>
        public static string UserCreditLookGradeByBarcode(string borrowerBarcode)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@BorrowerBarcode",borrowerBarcode)         
            };
            string userCreditCreditGrade = Convert.ToString(SQLHelper.ExecuteScalar("UserCreditLookGradeByBarcode", CommandType.StoredProcedure, p));
            return userCreditCreditGrade;
        }

        /// <summary>
        /// 根据帐号修改用户等级信息
        /// </summary>
        /// <param name="userCredit"></param>
        /// <returns>bool值</returns>
        public static bool UserCreditUpdate(Model.UserCredit userCredit)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@BorrowerBarcode",userCredit.UserCreditBorrowerBarcode),
                new SqlParameter("@LatePicklTimes",userCredit.UserCreditLatePicklTimes),
                new SqlParameter("@CancelPickTimes",userCredit.UserCreditCancelPickTimes),
                new SqlParameter("@DeferReTimes",userCredit.UserCreditDeferReTimes),
                new SqlParameter("@BreakCycTimes",userCredit.UserCreditBreakCycTimes),
                new SqlParameter("@NotReplaceTimes",userCredit.UserCreditNotReplaceTimes),
                new SqlParameter("@AllTimes",userCredit.UserCreditAllTimes)       
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserCreditUpdate", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int UserCreditYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@count",count)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("UserCreditYs", CommandType.StoredProcedure, p));
            return i;
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool UserCreditLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
            };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("UserCreditLookID", CommandType.StoredProcedure, p));

            return f == 1;   //为真表示存在
        }
    }
}
