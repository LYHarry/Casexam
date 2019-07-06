using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    /// <summary>
    /// 订单评价表BLL
    /// </summary>
    public class OrderAppraiseBusiness
    {
        /// <summary>
        /// 添加订单评价表信息
        /// </summary>
        /// <param name="orderAppraise"></param>
        /// <returns></returns>
        public static bool OrderAppraiseAdd(Model.OrderAppraise orderAppraise)
        {
            return DAL.OrderAppraiseDataAccess.OrderAppraiseAdd(orderAppraise);
        }

        /// <summary>
        /// 根据订单的编号删除数据
        /// </summary>
        /// <param name="OrderappraiseBowId"></param>
        /// <returns></returns>
        public static bool OrderAppraiseDel(int OrderappraiseBowId)
        {
            return DAL.OrderAppraiseDataAccess.OrderAppraiseDel(OrderappraiseBowId);
        }

        /// <summary>
        /// 根据订单表编号查询订单的评价内容
        /// </summary>
        /// <param name="OrderappraiseBowId"></param>
        /// <returns></returns>
        public static List<Model.OrderAppraise> orderAppraise(int OrderappraiseBowId)
        {
            return DAL.OrderAppraiseDataAccess.orderAppraise(OrderappraiseBowId);
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.OrderAppraise> OrderAppraiseFeny(int ys, int count)
        {
            return DAL.OrderAppraiseDataAccess.OrderAppraiseFeny(ys, count);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int OrderAppraiseYs(int count)
        {
            return DAL.OrderAppraiseDataAccess.OrderAppraiseYs(count);
        }

        /// <summary>
        /// 查询所有的订单评价表内容
        /// </summary>
        /// <returns></returns>
        public static List<Model.OrderAppraise> OrderAppraiseLookAll()
        {
            return DAL.OrderAppraiseDataAccess.OrderAppraiseLookAll();
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool OrderAppLookId(int id)
        {
            return DAL.OrderAppraiseDataAccess.OrderAppLookId(id);
        }

    }
}
