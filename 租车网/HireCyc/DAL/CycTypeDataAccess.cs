using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 车辆类型表DAL
    /// </summary>
    public class CycTypeDataAccess
    {
        /// <summary> 
        /// 添加车辆类型
        /// </summary>
        /// <param name="cycType"></param>
        /// <returns>bool值</returns>
        public static bool CycTypeAdd(Model.CycType cycType)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@Name",cycType.CycTypeName),
                new SqlParameter("@Stock",cycType.CycTypeStock),
                new SqlParameter("@Hire",cycType.CycTypeHire),
                new SqlParameter("@LagHrMoney",cycType.CycTypeLagHrMoney),
                new SqlParameter("@LagDayMoney",cycType.CycTypeLagDayMoney),
                new SqlParameter("@LateHrMoney",cycType.CycTypeLateHrMoney),
                new SqlParameter("@LateDayMoney",cycType.CycTypeLateDayMoney)         
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycTypeAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 删除车辆类型
        /// </summary>
        /// <param name="name">车辆类型名称</param>
        /// <returns>bool值</returns>
        public static bool CycTypeDel(string name)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                    new SqlParameter("@name",name)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycTypeDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 查询所有的数据,并根据车辆库存排序
        /// </summary>
        /// <returns>list值</returns>
        public static List<Model.CycType> CycTypeLookAll()
        {
            List<Model.CycType> list = new List<Model.CycType>();//创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycTypeLookAll", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CycType cycType = new Model.CycType();

                cycType.CycTypeName = Convert.ToString(sdr["车辆类型名称"]);
                cycType.CycTypeStock = Convert.ToInt32(sdr["车辆的库存"]);
                cycType.CycTypeHire = Convert.ToSingle(sdr["车辆的押金"]);
                cycType.CycTypeLagHrMoney = Convert.ToSingle(sdr["车辆租金_小时"]);
                cycType.CycTypeLagDayMoney = Convert.ToSingle(sdr["车辆租金_天"]);
                cycType.CycTypeLateHrMoney = Convert.ToSingle(sdr["车辆迟还时的租金_小时"]);
                cycType.CycTypeLateDayMoney = Convert.ToSingle(sdr["车辆迟还时的租金_天"]);
                list.Add(cycType);
            }
            return list;
        }

        /// <summary>
        /// 查询所有的车辆类型名称
        /// </summary>
        /// <returns>list值</returns>
        public static List<string> CycTypeLookAllName()
        {
            List<string> list = new List<string>();//创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycTypeLookAllName", CommandType.StoredProcedure);

            while (sdr.Read())
            {
                string CycTypeName = Convert.ToString(sdr["车辆类型名称"]);
                list.Add(CycTypeName);
            }
            return list;
        }

        /// <summary>
        /// 根据车辆类型查询数据
        /// </summary>
        /// <param name="name">车辆类型名称</param>
        /// <returns>list值</returns>
        public static Model.CycType CycTypeLookByName(string name)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@name",name)
            };           
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycTypeLookByName", CommandType.StoredProcedure,p);
            Model.CycType cycType = new Model.CycType();

            while (sdr.Read())
            {
                cycType.CycTypeStock = Convert.ToInt32(sdr["车辆的库存"]);
                cycType.CycTypeHire = Convert.ToSingle(sdr["车辆的押金"]);
                cycType.CycTypeLagHrMoney = Convert.ToSingle(sdr["车辆租金_小时"]);
                cycType.CycTypeLagDayMoney = Convert.ToSingle(sdr["车辆租金_天"]);
                cycType.CycTypeLateHrMoney = Convert.ToSingle(sdr["车辆迟还时的租金_小时"]);
                cycType.CycTypeLateDayMoney = Convert.ToSingle(sdr["车辆迟还时的租金_天"]);
            }
            return cycType;
        }

        /// <summary>
        /// 查询所有数据，根据押金排序
        /// </summary>
        /// <returns>list值</returns>
        public static List<Model.CycType> CycTypeLookBypx()
        {
            List<Model.CycType> list = new List<Model.CycType>();//创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycTypeLookBypx", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CycType cycType = new Model.CycType();

                cycType.CycTypeName = Convert.ToString(sdr["车辆类型名称"]);
                cycType.CycTypeStock = Convert.ToInt32(sdr["车辆的库存"]);
                cycType.CycTypeHire = Convert.ToSingle(sdr["车辆的押金"]);
                cycType.CycTypeLagHrMoney = Convert.ToSingle(sdr["车辆租金_小时"]);
                cycType.CycTypeLagDayMoney = Convert.ToSingle(sdr["车辆租金_天"]);
                cycType.CycTypeLateHrMoney = Convert.ToSingle(sdr["车辆迟还时的租金_小时"]);
                cycType.CycTypeLateDayMoney = Convert.ToSingle(sdr["车辆迟还时的租金_天"]);
                list.Add(cycType);
            }
            return list;
        }

        /// <summary>
        /// 修改车辆的押金，车辆租金(小时)，车辆租金（天），车辆迟还时的租金(小时)，车辆迟还时的租金（天）
        /// </summary>
        /// <param name="cycType"></param>
        /// <returns>bool值</returns>
        public static bool CycTypeUpdateMoney(Model.CycType cycType)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
                new SqlParameter("@Name",cycType.CycTypeName),
                new SqlParameter("@Hire",cycType.CycTypeHire),
                new SqlParameter("@LagHrMoney",cycType.CycTypeLagHrMoney),
                new SqlParameter("@LagDayMoney",cycType.CycTypeLagDayMoney),
                new SqlParameter("@LateHrMoney",cycType.CycTypeLateHrMoney),
                new SqlParameter("@LateDayMoney",cycType.CycTypeLateDayMoney)         
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycTypeUpdateMoney", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        ///  修改库存，根据车辆类型名称
        /// </summary>
        /// <param name="name">车辆类型名称</param>
        /// <param name="stock">库存</param>
        /// <returns>bool值</returns>
        public static bool CycTypeUpdateStock(string name, int stock)
        {
            SqlParameter[] p = new SqlParameter[] 
            {
              new SqlParameter("@Name",name),
              new SqlParameter("@Stock",stock)       
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycTypeUpdateStock", CommandType.StoredProcedure, p));
            return i > 0;
        }

    }
}
