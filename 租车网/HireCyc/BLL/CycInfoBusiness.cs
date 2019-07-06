using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 车辆信息表BLL
    /// </summary>
    public class CycInfoBusiness
    {
        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="cycInfo"></param>
        /// <returns></returns>
        public static bool CycInfoAdd(Model.CycInfo cycInfo)
        {
            return DAL.CycInfoDataAccess.CycInfoAdd(cycInfo);
        }

        /// <summary>
        /// 根据车辆名称删除车辆信息
        /// </summary>
        /// <param name="CycName"></param>
        /// <returns></returns>
        public static bool CycInfoDel(string CycName)
        {
            return DAL.CycInfoDataAccess.CycInfoDel(CycName);
        }

        /// <summary>
        /// 根据名称查询车辆信息
        /// </summary>
        /// <param name="CycName"></param>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByName(string CycName)
        {
            return DAL.CycInfoDataAccess.CycInfoLookByName(CycName);
        }

        /// <summary>
        /// 根据车辆类型查询车辆信息
        /// </summary>
        /// <param name="CycType"></param>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByType(string CycType)
        {
            return DAL.CycInfoDataAccess.CycInfoLookByType(CycType);
        }

        /// <summary>
        /// 根据车辆类型查询车辆名称
        /// </summary>
        /// <param name="CycType"></param>
        /// <returns></returns>
        public static List<string> CycInfoLookNameByType(string CycType)
        {
            return DAL.CycInfoDataAccess.CycInfoLookNameByType(CycType);
        }

        /// <summary>
        /// 根据购车时间段查询
        /// </summary>
        /// <param name="CycBuyTime1"></param>
        /// <param name="CycBuyTime2"></param>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByTime(DateTime CycBuyTime1, DateTime CycBuyTime2)
        {
            return DAL.CycInfoDataAccess.CycInfoLookByTime(CycBuyTime1, CycBuyTime2);
        }

        /// <summary>
        /// 查看所有车辆信息并根据自行车被租用次数排序
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByBspx()
        {
            return DAL.CycInfoDataAccess.CycInfoLookByBspx();
        }

        /// <summary>
        /// 查看所有车辆信息并根据自行车修理次数排序
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycInfo> CycInfoLookByRepx()
        {
            return DAL.CycInfoDataAccess.CycInfoLookByRepx();
        }

        /// <summary>
        /// 修改自行车被租用次数
        /// </summary>
        /// <param name="CycName"></param>
        /// <param name="CycBorrowSun"></param>
        /// <returns></returns>
        public static bool CycInfoUpdateBowrrowSun(string CycName, int CycBorrowSun)
        {
            return DAL.CycInfoDataAccess.CycInfoUpdateBowrrowSun(CycName, CycBorrowSun);
        }

        /// <summary>
        /// 修改车辆修理次数
        /// </summary>
        /// <param name="CycName"></param>
        /// <param name="repair"></param>
        /// <returns></returns>
        public static bool CycInfoUpdateRepair(string CycName, int repair)
        {
            return DAL.CycInfoDataAccess.CycInfoUpdateRepair(CycName, repair);
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycInfo> CycInfoFeny(int ys, int count)
        {
            return DAL.CycInfoDataAccess.CycInfoFeny(ys, count);
        }


        /// <summary>
        /// 分页，计算总条数
        /// </summary>
        /// <returns></returns>
        public static int CycInfoYs()
        {
            return DAL.CycInfoDataAccess.CycInfoYs();
        }

        /// <summary>
        /// 分页获得数据
        /// </summary>
        /// <param name="startPageIndex">显示的开始页下标</param>
        /// <param name="endPageIndex">显示的结束页下标</param>
        /// <returns></returns>
        public static DataSet CycInfoPage(int startPageIndex, int endPageIndex)
        {
            return DAL.CycInfoDataAccess.CycInfoPage(startPageIndex, endPageIndex);
        }

    }
}
