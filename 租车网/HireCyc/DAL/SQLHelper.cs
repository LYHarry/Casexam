using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace DAL
{
    /// <summary>
    /// 真正对数据库操作的类，其他项目可以直接使用
    /// </summary>
    public class SQLHelper
    {
        private static string strConn = ConfigurationManager.ConnectionStrings["StrConn"].ToString();

        /// <summary>
        /// 执行不带数据库参数的增、删、改的SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string SQLCmd, CommandType cmdType)
        {
            int row = 0;//保存返回影响的行数
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(SQLCmd, conn);
                    comm.CommandType = cmdType;
                    row = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return row;
        }


        /// <summary>
        /// 执行带数据库参数的增、删、改的SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <param name="par">数据库参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string SQLCmd, CommandType cmdType, SqlParameter[] par)
        {
            int row = 0;//保存返回影响的行数
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(SQLCmd, conn);
                    comm.CommandType = cmdType;
                    comm.Parameters.AddRange(par);
                    row = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return row;
        }


        /// <summary>
        /// 执行不带数据库参数的查询结果集的SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <returns>返回DataSet结果集</returns>
        public static DataSet ExecuteDataSet(string SQLCmd, CommandType cmdType)
        {
            DataSet ds = new DataSet();  //创建DataSet对象，用于保存结果集
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(SQLCmd, conn);
                    sda.SelectCommand.CommandType = cmdType;
                    sda.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ds;
        }


        /// <summary>
        /// 执行带数据库参数的查询结果集的SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <param name="par">数据库参数</param>
        /// <returns>返回DataSet结果集</returns>
        public static DataSet ExecuteDataSet(string SQLCmd, CommandType cmdType, SqlParameter[] par)
        {
            DataSet ds = new DataSet();  //创建DataSet对象，用于保存结果集
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(SQLCmd, conn);
                    sda.SelectCommand.Parameters.AddRange(par);
                    sda.SelectCommand.CommandType = cmdType;
                    sda.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ds;
        }


        /// <summary>
        /// 执行结果只有一行一列,不带数据库参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <returns>返回查询后的结果</returns>
        public static object ExecuteScalar(string SQLCmd, CommandType cmdType)
        {
            object o = new object();  //用于保存查询的第一行结果
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(SQLCmd, conn);
                    comm.CommandType = cmdType;
                    o = comm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return o;
        }


        /// <summary>
        /// 执行结果只有一行一列,带数据库参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <param name="par">数据库参数</param>
        /// <returns>返回查询后的结果</returns>
        public static object ExecuteScalar(string SQLCmd, CommandType cmdType, SqlParameter[] par)
        {
            object o = new object();  //用于保存查询的第一行结果
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(SQLCmd, conn);
                    comm.Parameters.AddRange(par);
                    comm.CommandType = cmdType;
                    o = comm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return o;
        }


        /// <summary>
        /// 执行不带数据库参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <returns>返回DataReader查询结果集</returns>
        public static SqlDataReader ExecuteDataReader(string SQLCmd, CommandType cmdType)
        {
            SqlDataReader sdr = null;  //用于保存查询的DataReader结果集
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                comm.CommandType = cmdType;
                sdr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sdr;
        }


        /// <summary>
        /// 执行不带数据库参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <param name="par">数据库参数</param>
        /// <returns>返回DataReader查询结果集</returns>
        public static SqlDataReader ExecuteDataReader(string SQLCmd, CommandType cmdType, SqlParameter[] par)
        {
            SqlDataReader sdr = null;  //用于保存查询的DataReader结果集
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLCmd, conn);
                comm.Parameters.AddRange(par);
                comm.CommandType = cmdType;
                sdr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sdr;
        }

        /// <summary>
        /// 执行带数据库参数的查询结果集的SQL语句或存储过程（含数据源）
        /// </summary>
        /// <param name="SQLCmd">SQL语句或存储过程语句</param>
        /// <param name="dt">数据库名称</param>
        /// <param name="cmdType">语句的类型（SQL、存储过程）</param>
        /// <param name="par">数据库参数</param>
        /// <returns>返回DataSet结果集</returns>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string SQLCmd, string dt, CommandType cmdType, SqlParameter[] par)
        {
            DataSet ds = new DataSet();  //创建DataSet对象，用于保存结果集
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(SQLCmd, conn);
                    sda.SelectCommand.Parameters.AddRange(par);
                    sda.SelectCommand.CommandType = cmdType;
                    sda.Fill(ds, dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ds;
        }
    }
}
