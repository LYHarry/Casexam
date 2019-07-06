using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 车辆信息表的处理
    /// </summary>
    public class CycInfoDataAccess
    {
        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="cycInfo"></param>
        /// <returns></returns>
        public static bool CycInfoAdd(Model.CycInfo cycInfo)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Name",cycInfo.CycName),
                new SqlParameter("@Type",cycInfo.CycType),   
                new SqlParameter("@BowrrowSun",cycInfo.CycBowrrowSun),
                new SqlParameter("@Repair",cycInfo.CycRepair),
                new SqlParameter("@Money",cycInfo.CycMoney)                
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycInfoAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据车辆名称删除车辆信息
        /// </summary>
        /// <param name="CycName"></param>
        /// <returns></returns>
        public static bool CycInfoDel(string CycName)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Name",CycName)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycInfoDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据名称查询车辆信息
        /// </summary>
        /// <param name="CycName"></param>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByName(string CycName)
        {
            List<Model.CycInfo> list = new List<Model.CycInfo>();
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Name",CycName)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoLookByName", CommandType.StoredProcedure, p);


            while (dr.Read())
            {
                Model.CycInfo cycInfo = new Model.CycInfo();
                cycInfo.CycName = dr["自行车名称"].ToString();
                cycInfo.CycType = dr["车辆类型名称"].ToString();
                cycInfo.CycBowrrowSun = Convert.ToInt32(dr["自行车被租用次数"]);
                cycInfo.CycBuyTime = Convert.ToDateTime(dr["购车时间"]);
                cycInfo.CycRepair = Convert.ToInt32(dr["修理次数"]);
                cycInfo.CycMoney = Convert.ToSingle(dr["车价"]);
                list.Add(cycInfo);
            }
            return list;
        }

        /// <summary>
        /// 根据车辆类型查询车辆信息
        /// </summary>
        /// <param name="CycType"></param>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByType(string CycType)
        {
            List<Model.CycInfo> list = new List<Model.CycInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Type",CycType)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoLookByType", CommandType.StoredProcedure, p);

            while (dr.Read())
            {
                Model.CycInfo ci = new Model.CycInfo();

                ci.CycName = dr["自行车名称"].ToString();
                ci.CycType = dr["车辆类型名称"].ToString();
                ci.CycBowrrowSun = Convert.ToInt32(dr["自行车被租用次数"]);
                ci.CycBuyTime = Convert.ToDateTime(dr["购车时间"]);
                ci.CycRepair = Convert.ToInt32(dr["修理次数"]);
                ci.CycMoney = Convert.ToSingle(dr["车价"]);

                list.Add(ci);
            }

            return list;
        }



        /// <summary>
        /// 根据车辆类型查询车辆名称
        /// </summary>
        /// <param name="CycType"></param>
        /// <returns></returns>
        public static List<string> CycInfoLookNameByType(string CycType)
        {
            List<string> list = new List<string>();

            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Type",CycType)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoLookNameByType", CommandType.StoredProcedure, p);

            while (dr.Read())
            {
                string CycName = dr["自行车名称"].ToString();
                list.Add(CycName);
            }
            return list;
        }


        /// <summary>
        /// 根据购车时间段查询
        /// </summary>
        /// <param name="CycBuyTime1"></param>
        /// <param name="CycBuyTime2"></param>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByTime(DateTime CycBuyTime1, DateTime CycBuyTime2)
        {
            List<Model.CycInfo> list = new List<Model.CycInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Time1",CycBuyTime1),
               new SqlParameter("@Time2",CycBuyTime2)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoLookByTime", CommandType.StoredProcedure, p);

            while (dr.Read())
            {
                Model.CycInfo cycInfo = new Model.CycInfo();

                cycInfo.CycName = dr["自行车名称"].ToString();
                cycInfo.CycType = dr["车辆类型名称"].ToString();
                cycInfo.CycBowrrowSun = Convert.ToInt32(dr["自行车被租用次数"]);
                cycInfo.CycBuyTime = Convert.ToDateTime(dr["购车时间"]);
                cycInfo.CycRepair = Convert.ToInt32(dr["修理次数"]);
                cycInfo.CycMoney = Convert.ToSingle(dr["车价"]);
                list.Add(cycInfo);
            }
            return list;
        }

        /// <summary>
        /// 查看所有车辆信息并根据自行车被租用次数排序
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByBspx()
        {
            List<Model.CycInfo> list = new List<Model.CycInfo>();

            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoLookByBspx", CommandType.StoredProcedure);

            while (dr.Read())
            {
                Model.CycInfo cycInfo = new Model.CycInfo();
                cycInfo.CycName = dr["自行车名称"].ToString();
                cycInfo.CycType = dr["车辆类型名称"].ToString();
                cycInfo.CycBowrrowSun = Convert.ToInt32(dr["自行车被租用次数"]);
                cycInfo.CycBuyTime = Convert.ToDateTime(dr["购车时间"]);
                cycInfo.CycRepair = Convert.ToInt32(dr["修理次数"]);
                cycInfo.CycMoney = Convert.ToSingle(dr["车价"]);
                list.Add(cycInfo);
            }
            return list;
        }

        /// <summary>
        /// 查看所有车辆信息并根据自行车修理次数排序
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByRepx()
        {
            List<Model.CycInfo> list = new List<Model.CycInfo>();

            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoLookByRepx", CommandType.StoredProcedure);

            while (dr.Read())
            {
                Model.CycInfo cycInfo = new Model.CycInfo();

                cycInfo.CycName = dr["自行车名称"].ToString();
                cycInfo.CycType = dr["车辆类型名称"].ToString();
                cycInfo.CycBowrrowSun = Convert.ToInt32(dr["自行车被租用次数"]);
                cycInfo.CycBuyTime = Convert.ToDateTime(dr["购车时间"]);
                cycInfo.CycRepair = Convert.ToInt32(dr["修理次数"]);
                cycInfo.CycMoney = Convert.ToSingle(dr["车价"]);
                list.Add(cycInfo);
            }
            return list;
        }

        /// <summary>
        /// 修改自行车被租用次数
        /// </summary>
        /// <param name="CycName"></param>
        /// <param name="CycBorrowSun"></param>
        /// <returns></returns>
        public static bool CycInfoUpdateBowrrowSun(string CycName, int CycBorrowSun)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Name",CycName),
                new SqlParameter("@BowrrowSun",CycBorrowSun)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycInfoUpdateBowrrowSun", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 修改车辆修理次数
        /// </summary>
        /// <param name="CycName"></param>
        /// <param name="repair"></param>
        /// <returns></returns>
        public static bool CycInfoUpdateRepair(string CycName, int repair)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Name",CycName),
                new SqlParameter("@Repair",repair)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycInfoUpdateRepair", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycInfo> CycInfoFeny(int ys, int count)
        {
            List<Model.CycInfo> list = new List<Model.CycInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@ys",ys),
               new SqlParameter("@count",count)
            };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycInfoFeny", CommandType.StoredProcedure, p);

            while (dr.Read())
            {
                Model.CycInfo cycInfo = new Model.CycInfo();
                cycInfo.CycId = Convert.ToInt32(dr["编号"]);
                cycInfo.CycName = dr["自行车名称"].ToString();
                cycInfo.CycType = dr["车辆类型名称"].ToString();
                cycInfo.CycBowrrowSun = Convert.ToInt32(dr["自行车被租用次数"]);
                cycInfo.CycBuyTime = Convert.ToDateTime(dr["购车时间"]);
                cycInfo.CycRepair = Convert.ToInt32(dr["修理次数"]);
                cycInfo.CycMoney = Convert.ToSingle(dr["车价"]);
                list.Add(cycInfo);
            }
            return list;
        }

        /// <summary>
        /// 分页，计算总条数
        /// </summary>
        /// <returns></returns>
        public static int CycInfoYs()
        {
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycInfoYs", CommandType.StoredProcedure));
            return i;
        }

        /// <summary>
        /// 分页获得数据
        /// </summary>
        /// <param name="startPageIndex">显示的开始页下标</param>
        /// <param name="endPageIndex">显示的结束页下标</param>
        /// <returns></returns>
        public static DataSet CycInfoPage(int startPageIndex, int endPageIndex)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@startPageIndex",startPageIndex),
               new SqlParameter("@endPageIndex",endPageIndex)
            };
            DataSet dr = SQLHelper.ExecuteDataSet("CycInfoPage", "CycHire", CommandType.StoredProcedure, p);

            return dr;
        }

    }
}