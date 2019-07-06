using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 订单表BLL
    /// </summary>
    public class CycBorrowBusiness
    {
        /// <summary>
        /// 添加订单数据
        /// </summary>
        /// <param name="cb">订单对象</param>
        /// <returns></returns>
        public static bool CycBorrowAdd(Model.CycBorrow cb)
        {
            return DAL.CycBorrowDataAccess.CycBorrowAdd(cb);
        }

        /// <summary>
        /// 根据订单编号删除数据
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowDel(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowDel(id);
        }

        /// <summary>
        /// 根据用户编号查询总租车次数
        /// </summary>
        /// <param name="code">用户编号</param>
        /// <returns>int值</returns>
        public static int CycBorrowLookAllTime(string code)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookAllTime(code);
        }

        /// <summary>
        /// 根据订单编号查询该订单内是否有毁坏车辆情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookBreakCycTimes(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookBreakCycTimes(id);
        }

        /// <summary>
        /// 根据用户帐号查询订单数据
        /// </summary>
        /// <param name="BowCode">用户帐号</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookBycode(string BowCode)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookBycode(BowCode);
        }

        /// <summary>
        /// 查询某员工处理的订单
        /// </summary>
        /// <param name="empcode">员工编号</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookByEmpcode(string empcode)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookByEmpcode(empcode);
        }

        /// <summary>
        /// 根据订单状态查询订单信息
        /// </summary>
        /// <param name="status">订单状态</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookByStatus(string status)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookByStatus(status);
        }

        /// <summary>
        /// 根据时间段查询用户的订单
        /// </summary>
        /// <param name="t1">时间段的起始时间</param>
        /// <param name="t2">时间段的结束时间 </param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowLookByTimeD(DateTime t1, DateTime t2)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookByTimeD(t1, t2);
        }

        /// <summary>
        /// 判断该订单内是否有不取车的情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookCancelPickTimes(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookCancelPickTimes(id);
        }

        /// <summary>
        /// 判断该订单中是否有迟还车的情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookDeferReTimes(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookDeferReTimes(id);
        }

        /// <summary>
        /// 根据帐号查找最新的订单编号
        /// </summary>
        /// <param name="BowCode">用户帐号</param>
        /// <returns></returns>
        public static int CycBorrowLookIdBycode(string BowCode)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookIdBycode(BowCode);
        }

        /// <summary>
        /// 根据用户帐号查询最新的一条订单数据
        /// </summary>
        /// <param name="BowCode">用户帐号</param>
        /// <returns></returns>
        public static Model.CycBorrow CycBorrowLookNewBycode(string BowCode)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookNewBycode(BowCode);
        }

        /// <summary>
        /// 根据订单编号判断是否有推迟取车情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookLatePicklTimes(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookLatePicklTimes(id);
        }

        /// <summary>
        /// 判断该订单是否有不还车情况
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowLookNotReplaceTimes(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookNotReplaceTimes(id);
        }

        /// <summary>
        /// 根据订单号修改该辆车的最后租金
        /// </summary>
        /// <param name="id">订单号</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowUpdateRealMoney(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowUpdateRealMoney(id);
        }

        /// <summary>
        ///根据订单编号修改订单状态
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns>bool值</returns>
        public static bool CycBorrowUpdateStatus(int id, string status)
        {
            return DAL.CycBorrowDataAccess.CycBorrowUpdateStatus(id, status);
        }

        /// <summary>
        /// 根据每页的条数计算出总页数
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值</returns>
        public static int CycBorrowYs(int count)
        {
            return DAL.CycBorrowDataAccess.CycBorrowYs(count);
        }

        /// <summary>
        /// **************分页显示*******************8？
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycBorrow> CycBorrowFeny(int ys, int count)
        {
            return DAL.CycBorrowDataAccess.CycBorrowFeny(ys, count);
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool CycBorrowLookId(int id)
        {
            return DAL.CycBorrowDataAccess.CycBorrowLookId(id);
        }
    }
}
