using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UserCreditBusiness
    {
       /// <summary>
        /// 添加用户等级信息
        /// </summary>
        /// <param name="userCredit"></param>
        /// <returns>bool值</returns>
        public static bool UserCreditAdd(string BorrowerBarcode)
        {
            return DAL.UserCreditDataAccess.UserCreditAdd(BorrowerBarcode);
        }

        /// <summary>
        /// 根据账号删除用户等级表信息
        /// </summary>
        /// <param name="borrowerBarcode">帐号</param>
        /// <returns>bool值</returns>
        public static bool UserCreditDel(string borrowerBarcode)
        {
            return DAL.UserCreditDataAccess.UserCreditDel(borrowerBarcode);
        }

        /// <summary>
        /// 根据用户帐号查询数据
        /// </summary>
        /// <param name="borrowerBarcode">帐号</param>
        /// <returns>list值</returns>
        public static List<Model.UserCredit> UserCreditLookByBorrowerBarcode(string borrowerBarcode)
        {
            return DAL.UserCreditDataAccess.UserCreditLookByBorrowerBarcode(borrowerBarcode);
        }

        /// <summary>
        /// *******分页显示*************？
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页条数</param>
        /// <returns>list值</returns>
        public static List<Model.UserCredit> UserCreditFeny(int ys, int count)
        {
            return DAL.UserCreditDataAccess.UserCreditFeny(ys,count);
        }

        /// <summary>
        /// 根据用户帐号查看信用等级
        /// </summary>
        /// <param name="borrowerBarcode">帐号</param>
        /// <returns>string值，信用等级</returns>
        public static string UserCreditLookGradeByBarcode(string borrowerBarcode)
        {
            return DAL.UserCreditDataAccess.UserCreditLookGradeByBarcode(borrowerBarcode);
        }

        /// <summary>
        /// 根据帐号修改用户等级信息
        /// </summary>
        /// <param name="userCredit"></param>
        /// <returns>bool值</returns>
        public static bool UserCreditUpdate(Model.UserCredit userCredit)
        {
            return DAL.UserCreditDataAccess.UserCreditUpdate(userCredit);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int UserCreditYs(int count)
        {
            return DAL.UserCreditDataAccess.UserCreditYs(count);
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool UserCreditLookId(int id)
        {
            return DAL.UserCreditDataAccess.UserCreditLookId(id);
        }
    }

    }

