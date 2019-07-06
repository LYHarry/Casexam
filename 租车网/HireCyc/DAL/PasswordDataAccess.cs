using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 加密信息表DAL
    /// </summary>
    public class PasswordDataAccess
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="username">用户账号</param>
        /// <param name="keyt">随机产生的密钥</param>
        /// <returns></returns>
        public static bool PasswordAdd(string username, string keyt)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@Account",username),
                new SqlParameter("@pass",keyt)   
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PasswordAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据用户帐号删除数据
        /// </summary>
        /// <param name="Account">用户帐号</param>
        /// <returns>bool值</returns>
        public static bool PasswordDelByAccount(string Account)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",Account)         
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PasswordDelByAccount", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据帐号查询密码
        /// </summary>
        /// <param name="Account">帐号</param>
        /// <returns>string值，密码</returns>
        public static string PasswordLookpassByAccount(string Account)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Account",Account)         
            };

            string password = SQLHelper.ExecuteScalar("PasswordLookpassByAccount", CommandType.StoredProcedure, p).ToString();

            return password;
        }

      /// <summary>
        /// 根据帐号，修改加密信息
      /// </summary>
      /// <param name="uername">用户账号</param>
      /// <param name="keyt">新密码</param>
      /// <returns></returns>
        public static bool PasswordUpdateByAccount(string uername, string keyt)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@Account",uername),
                new SqlParameter("@pass",keyt)   
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PasswordUpdateByAccount", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 查询所有密钥
        /// </summary>
        /// <returns></returns>
        public static List<string> PasswordLookALLPaw()
        {
            List<string> list = new List<string>();//创建List集合        

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("PasswordLookALLpass", CommandType.StoredProcedure);

            while (sdr.Read())
            {
                string paw = sdr["密钥"].ToString();
                list.Add(paw);
            }
            return list;
        }


    }
}
