using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 车辆租用信息表DAL
    /// </summary>
    public class CycRentDataAccess  
    {
        /// <summary>
        /// 添加车辆租用信息表数据
        /// </summary>
        /// <param name="cycRent"></param>
        /// <returns>bool值</returns>
        public static bool CycRentAdd(Model.CycRent cycRent)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@CycName",cycRent.CycRentCycName),
                new SqlParameter("@CycType",cycRent.CycRentCycType),
                new SqlParameter("@BorrowId",cycRent.CycRentBorrowId),
                new SqlParameter("@Time",cycRent.CycRentTime),
                new SqlParameter("@ReturnTime",cycRent.CycRentReturnTime)      
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycRentAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据编号删除数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>bool值</returns>
        public static bool CycRentDel(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@id",id)         
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycRentDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据订单编号查询
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>list值</returns>
        public static List<Model.CycRent> CycRentLookByBowId(int id)
        {
            List<Model.CycRent> list = new List<Model.CycRent>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@id",id)         
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycRentLookByBowId", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycRent cycRent = new Model.CycRent();

                cycRent.CycRentCycName = Convert.ToString(sdr["自行车名称"]);
                cycRent.CycRentCycType = Convert.ToString(sdr["自行车类型"]);
                cycRent.CycRentRealityBorrowTime = Convert.ToDateTime(sdr["取车时间"]);
                cycRent.CycRentRealityReturnTime = Convert.ToDateTime(sdr["还车时间"]);
                cycRent.CycRentCycDam = Convert.ToInt32(sdr["毁坏情况"]);
                cycRent.CycRentBorrowId = Convert.ToInt32(sdr["订单编号"]);
                cycRent.CycRentTime = Convert.ToDateTime(sdr["预定取车时间"]);
                cycRent.CycRentReturnTime = Convert.ToDateTime(sdr["预定还车时间"]);
                cycRent.CycRentMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycRent);
            }
            return list;
        }

        /// <summary>
        /// ************分页显示************？
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycRent> CycRentFeny(int ys, int count)
        {
            List<Model.CycRent> list = new List<Model.CycRent>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@ys",ys),
                new SqlParameter("@count",count)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycRentFeny", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycRent cycRent = new Model.CycRent();

                cycRent.CycRentId = Convert.ToInt32(sdr["编号"]);
                cycRent.CycRentCycName = Convert.ToString(sdr["自行车名称"]);
                cycRent.CycRentCycType = Convert.ToString(sdr["自行车类型"]);
                cycRent.CycRentRealityBorrowTime = Convert.ToDateTime(sdr["取车时间"]);
                cycRent.CycRentRealityReturnTime = Convert.ToDateTime(sdr["还车时间"]);
                cycRent.CycRentCycDam = Convert.ToInt32(sdr["毁坏情况"]);
                cycRent.CycRentBorrowId = Convert.ToInt32(sdr["订单编号"]);
                cycRent.CycRentTime = Convert.ToDateTime(sdr["预定取车时间"]);
                cycRent.CycRentReturnTime = Convert.ToDateTime(sdr["预定还车时间"]);
                cycRent.CycRentMoney = Convert.ToSingle(sdr["租金"]);
                list.Add(cycRent);
            }
            return list;
        }

        /// <summary>
        /// 根据订单号和自行车名查询编号
        /// </summary>
        /// <param name="cycName">自行车名</param>
        /// <param name="borrowId">订单号</param>
        /// <returns>list值</returns>
        public static int CycRentLookIdByNameAndBowId(string cycName, int borrowId)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                 new SqlParameter("@CycName",cycName), 
                 new SqlParameter("@BorrowId",borrowId)        
            };
            int cycRentId = Convert.ToInt32(SQLHelper.ExecuteScalar("CycRentLookIdByNameAndBowId", CommandType.StoredProcedure, p));
            return cycRentId;
        }

        /// <summary>
        /// 计算该辆车的最终租金
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>float值</returns>
        public static float CycRentSumMoney(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@id",id)        
            };
            float i = Convert.ToSingle(SQLHelper.ExecuteScalar("CycRentSumMoney", CommandType.StoredProcedure, p));
            return i;
        }

        /// <summary>
        /// 修改自行车的毁坏情况
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="cycDam">自行车毁坏情况编号</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateCycDam(int id, int cycDam)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                 new SqlParameter("@id",id), 
                 new SqlParameter("@CycDam",cycDam)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycRentUpdateCycDam", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 修改租金
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="money">租金</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateMoney(int id, float money)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id), 
               new SqlParameter("@Money ",money)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycRentUpdateMoney", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 修改实际取车时间
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="realityBorrowTime">实际取车时间</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateRealityBorrowTime(int id, DateTime realityBorrowTime)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@id",id), 
                new SqlParameter("@RealityBorrowTime ",realityBorrowTime)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycRentUpdateRealityBorrowTime", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 修改实际还车时间
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="realityReturnTime">实际还车时间</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateRealityReturnTime(int id, DateTime realityReturnTime)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@id",id), 
                new SqlParameter("@RealityReturnTime ",realityReturnTime)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycRentUpdateRealityReturnTime", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int CycRentYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@count",count)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycRentYs", CommandType.StoredProcedure, p));
            return i;
        }


        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool CycRentLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
            };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("CycRentLookID", CommandType.StoredProcedure, p));

            return f == 1;   //为真表示存在
        }
    }
}
