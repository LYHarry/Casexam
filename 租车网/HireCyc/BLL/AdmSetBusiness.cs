using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    /// <summary>
    /// 权限表BLL
    /// </summary>
  public  class AdmSetBusiness
    {
        /// <summary>
        /// 添加新权限,员工权限表数据
        /// </summary>
        /// <param name="admSet">要添加的权限对象</param>
        /// <returns></returns>
        public static bool AdmSetAdd(Model.AdmSet admSet)
        {
            return DAL.AdmSetDataAccess.AdmSetAdd(admSet);
        }

        /// <summary>
        /// 根据权限名称删除员工权限表信息
        /// </summary>
        /// <param name="AdmSetName">要删除的权限名称</param>
        /// <returns></returns>
        public static bool AdmSetDelete(string AdmSetName)
        {
            return DAL.AdmSetDataAccess.AdmSetDelete(AdmSetName);
        }

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="admSet">要修改的权限对象</param>
        /// <returns></returns>
        public static bool AdmSetUpdate(Model.AdmSet admSet)
        {
           return DAL.AdmSetDataAccess.AdmSetUpdate(admSet);
        }

        /// <summary>
        /// 查询员工权限表所有数据
        /// </summary>
        /// <returns></returns>
        public static List<Model.AdmSet> AdmSetLookAll()
        {
            return DAL.AdmSetDataAccess.AdmSetLookAll();
        }

        /// <summary>
        /// 查询员工权限表权限名称
        /// </summary>
        /// <returns></returns>
        public static List<string> AdmSetLookAllName()
        {
            return DAL.AdmSetDataAccess.AdmSetLookAllName();
        }

        /// <summary>
        /// 根据权限名称查询相应权限
        /// </summary>
        /// <param name="AdmSetName">要查询的权限名称</param>
        /// <returns></returns>
        public static Model.AdmSet AdmSetLookByName(string AdmSetName)
        {
            return DAL.AdmSetDataAccess.AdmSetLookByName(AdmSetName);
        }

        /// <summary>
        /// 根据表编号id查询权限名称
        /// </summary>
        /// <param name="AdmSetId">要查询的ID</param>
        /// <returns></returns>
        public static string AdmSetLookNameById(int AdmSetId)
        {
            return DAL.AdmSetDataAccess.AdmSetLookNameById(AdmSetId);
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool AdmSetLookId(int id)
        {
            return DAL.AdmSetDataAccess.AdmSetLookId(id);
        }
    }
}
