using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 车辆租用信息表BLL
    /// </summary>
   public class CycRentBusiness
    {
        /// <summary>
        /// 添加车辆租用信息表数据
        /// </summary>
        /// <param name="cycRent"></param>
        /// <returns>bool值</returns>
        public static bool CycRentAdd(Model.CycRent cycRent)
        {
            return DAL.CycRentDataAccess.CycRentAdd(cycRent);
        }

        /// <summary>
        /// 根据编号删除数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>bool值</returns>
        public static bool CycRentDel(int id)
        {
            return DAL.CycRentDataAccess.CycRentDel(id);
        }

        /// <summary>
        /// 根据订单编号查询
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>list值</returns>
        public static List<Model.CycRent> CycRentLookByBowId(int id)
        {
            return DAL.CycRentDataAccess.CycRentLookByBowId(id);
        }

        /// <summary>
        /// ************分页显示************？
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycRent> CycRentFeny(int ys, int count)
        {
            return DAL.CycRentDataAccess.CycRentFeny(ys, count);
        }

        /// <summary>
        /// 根据订单号和自行车名查询编号
        /// </summary>
        /// <param name="cycName">自行车名</param>
        /// <param name="borrowId">订单号</param>
        /// <returns>list值</returns>
        public static int CycRentLookIdByNameAndBowId(string cycName, int borrowId)
        {
            return DAL.CycRentDataAccess.CycRentLookIdByNameAndBowId(cycName, borrowId);
        }

        /// <summary>
        /// 计算该辆车的最终租金
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>float值</returns>
        public static float CycRentSumMoney(int id)
        {
            return DAL.CycRentDataAccess.CycRentSumMoney(id);
        }

        /// <summary>
        /// 修改自行车的毁坏情况
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="cycDam">自行车毁坏情况编号</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateCycDam(int id, int cycDam)
        {
            return DAL.CycRentDataAccess.CycRentUpdateCycDam(id, cycDam);
        }

        /// <summary>
        /// 修改租金
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="money">租金</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateMoney(int id, float money)
        {
            return DAL.CycRentDataAccess.CycRentUpdateMoney(id, money);
        }

        /// <summary>
        /// 修改实际取车时间
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="realityBorrowTime">实际取车时间</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateRealityBorrowTime(int id, DateTime realityBorrowTime)
        {
            return DAL.CycRentDataAccess.CycRentUpdateRealityBorrowTime(id, realityBorrowTime);
        }

        /// <summary>
        /// 修改实际还车时间
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="realityReturnTime">实际还车时间</param>
        /// <returns>bool值</returns>
        public static bool CycRentUpdateRealityReturnTime(int id, DateTime realityReturnTime)
        {
            return DAL.CycRentDataAccess.CycRentUpdateRealityReturnTime(id, realityReturnTime);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int CycRentYs(int count)
        {
            return DAL.CycRentDataAccess.CycRentYs(count);
        }


        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool CycRentLookId(int id)
        {
            return DAL.CycRentDataAccess.CycRentLookId(id);
        }
    }
}
