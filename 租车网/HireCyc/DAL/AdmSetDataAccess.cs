using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 权限表DAL
    /// </summary>
    public class AdmSetDataAccess
    {
        /// <summary>
        /// 添加新权限,员工权限表数据
        /// </summary>
        /// <param name="admSet">要添加的权限对象</param>
        /// <returns></returns>
        public static bool AdmSetAdd(Model.AdmSet admSet)
        {
            SqlParameter[] p = new SqlParameter[]
            {            
                new SqlParameter("@Name",admSet.AdmSetName),
                new SqlParameter("@SystemManage",admSet.AdmSetSystemManage),
                new SqlParameter("@BorrowerManage",admSet.AdmSetBorrowerManage),
                new SqlParameter("@CycManage",admSet.AdmSetCycManage),
                new SqlParameter("@EmpManage",admSet.AdmSetEmpManage),
                new SqlParameter("@BowManage",admSet.AdmSetBowManage),
                new SqlParameter("@BorrowerLook",admSet.AdmSetBorrowerLook),
                new SqlParameter("@CycLook",admSet.AdmSetCycLook),
                new SqlParameter("@EmpLook",admSet.AdmSetEmpLook),
                new SqlParameter("@BowLook",admSet.AdmSetBowLook)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("AdmSetAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据权限名称删除员工权限表信息
        /// </summary>
        /// <param name="AdmSetName">要删除的权限名称</param>
        /// <returns></returns>
        public static bool AdmSetDelete(string AdmSetName)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                 new SqlParameter("@name",AdmSetName)        
              };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("AdmSetDelete", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="admSet">要修改的权限对象</param>
        /// <returns></returns>
        public static bool AdmSetUpdate(Model.AdmSet admSet)
        {
            SqlParameter[] p = new SqlParameter[]
         {
            new SqlParameter("@Name",admSet.AdmSetName),
            new SqlParameter("@SystemManage",admSet.AdmSetSystemManage),
            new SqlParameter("@BorrowerManage",admSet.AdmSetBorrowerManage),
            new SqlParameter("@CycManage",admSet.AdmSetCycManage),
            new SqlParameter("@EmpManage",admSet.AdmSetEmpManage),
            new SqlParameter("@BowManage",admSet.AdmSetBowManage),
            new SqlParameter("@BorrowerLook",admSet.AdmSetBorrowerLook),
            new SqlParameter("@CycLook",admSet.AdmSetCycLook),
            new SqlParameter("@EmpLook",admSet.AdmSetEmpLook),
            new SqlParameter("@BowLook",admSet.AdmSetBowLook)
         };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("AdmSetUpdate", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 查询员工权限表所有数据
        /// </summary>
        /// <returns></returns>
        public static List<Model.AdmSet> AdmSetLookAll()
        {
            List<Model.AdmSet> list = new List<Model.AdmSet>();  //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("AdmSetLookAll", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.AdmSet admSet = new Model.AdmSet();
                admSet.AdmSetName = Convert.ToString(sdr["权限名称"]);
                admSet.AdmSetSystemManage = Convert.ToChar(sdr["系统设置权限"]);
                admSet.AdmSetBorrowerManage = Convert.ToChar(sdr["用户管理权限"]);
                admSet.AdmSetCycManage = Convert.ToChar(sdr["车辆管理权限"]);
                admSet.AdmSetEmpManage = Convert.ToChar(sdr["员工管理权限"]);
                admSet.AdmSetBowManage = Convert.ToChar(sdr["订单管理权限"]);
                admSet.AdmSetBorrowerLook = Convert.ToChar(sdr["用户查询权限"]);
                admSet.AdmSetCycLook = Convert.ToChar(sdr["车辆查询权限"]);
                admSet.AdmSetEmpLook = Convert.ToChar(sdr["员工查询权限"]);
                admSet.AdmSetBowLook = Convert.ToChar(sdr["订单查询权限"]);
                list.Add(admSet);
            }
            return list;
        }

        /// <summary>
        /// 查询员工权限表权限名称
        /// </summary>
        /// <returns></returns>
        public static List<string> AdmSetLookAllName()
        {
            List<string> list = new List<string>();  //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("AdmSetLookAllName", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                string AdmSetName = Convert.ToString(sdr["权限名称"]);
                list.Add(AdmSetName);
            }
            return list;
        }

        /// <summary>
        /// 根据权限名称查询相应权限
        /// </summary>
        /// <param name="AdmSetName">要查询的权限名称</param>
        /// <returns></returns>
        public static Model.AdmSet AdmSetLookByName(string AdmSetName)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Name",AdmSetName)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("AdmSetLookByName", CommandType.StoredProcedure, p);
            Model.AdmSet admSet = new Model.AdmSet();  //创建一个AmSet对象

            while (sdr.Read())
            {
                admSet.AdmSetSystemManage = Convert.ToChar(sdr["系统设置权限"]);
                admSet.AdmSetBorrowerManage = Convert.ToChar(sdr["用户管理权限"]);
                admSet.AdmSetCycManage = Convert.ToChar(sdr["车辆管理权限"]);
                admSet.AdmSetEmpManage = Convert.ToChar(sdr["员工管理权限"]);
                admSet.AdmSetBowManage = Convert.ToChar(sdr["订单管理权限"]);
                admSet.AdmSetBorrowerLook = Convert.ToChar(sdr["用户查询权限"]);
                admSet.AdmSetCycLook = Convert.ToChar(sdr["车辆查询权限"]);
                admSet.AdmSetEmpLook = Convert.ToChar(sdr["员工查询权限"]);
                admSet.AdmSetBowLook = Convert.ToChar(sdr["订单查询权限"]);
            }
            return admSet;
        }

        /// <summary>
        /// 根据表编号id查询权限名称
        /// </summary>
        /// <param name="AdmSetId">要查询的ID</param>
        /// <returns></returns>
        public static string AdmSetLookNameById(int AdmSetId)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Id",AdmSetId)
             };
            string AdmSetName = (SQLHelper.ExecuteScalar("AdmSetLookNameById", CommandType.StoredProcedure, p)).ToString();

            return AdmSetName;
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool AdmSetLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("AdmSetLookID", CommandType.StoredProcedure, p));

            return f == 1;   //为真表示存在
        }

    }
}
