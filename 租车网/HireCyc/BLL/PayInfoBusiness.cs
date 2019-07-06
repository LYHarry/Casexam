using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    /// <summary>
    /// 用户支付信息表（账户表）
    /// </summary>
    public class PayInfoBusiness
    {
        /// <summary>
        /// 添加支付信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool PayInfoAdd(Model.PayInfo payInfo)
        {
            return DAL.PayInfoDataAccess.PayInfoAdd(payInfo);
        }

        /// <summary>
        /// 判断某用户的支付宝或银行卡号是否为空
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <returns></returns>
        public static bool payInfoCodeAccIsExist(string PayInfoUserAcc)
        {
            return DAL.PayInfoDataAccess.payInfoCodeAccIsExist(PayInfoUserAcc);
        }

        /// <summary>
        /// 根据用户账号和卡号删除数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool PayInfoDel(string PayInfoUserAcc, string PayInfoCodeAcc)
        {
            return DAL.PayInfoDataAccess.PayInfoDel(PayInfoUserAcc, PayInfoCodeAcc);
        }


        /// <summary>
        /// 判断用户支付账号和密码输入是否正确
        /// </summary>
        /// <param name="PayInfoUserAcc">用户账号</param>
        /// <param name="PayInfoCodeAcc">支付账号</param>
        /// <param name="codeAccPaw">支付密码</param>
        /// <returns></returns>
        public static bool PayInfoLookUserAccALL(string PayInfoUserAcc, string PayInfoCodeAcc, string codeAccPaw)
        {
            return DAL.PayInfoDataAccess.PayInfoLookUserAccALL(PayInfoUserAcc, PayInfoCodeAcc, codeAccPaw);
        }
        /// <summary>
        /// 根据用户账号和卡号查询支付余额
        /// </summary>
        /// <param name="PayInfoUserAcc"></param>
        /// <param name="PayInfoCodeAcc"></param>
        /// <returns></returns>
        public static float PayInfoLookMoney(string PayInfoUserAcc, string PayInfoCodeAcc)
        {
            return DAL.PayInfoDataAccess.PayInfoLookMoney(PayInfoUserAcc, PayInfoCodeAcc);
        }

        /// <summary>
        /// 更改用户支付密码
        /// </summary>
        /// <param name="PayInfoUserAcc">用户账号</param>
        /// <param name="PayInfoCodeAcc">支付账号</param>
        /// <param name="PayInfoPassw">新密码</param>
        /// <returns></returns>
        public static bool PayInfoUpdate(string PayInfoUserAcc, string PayInfoCodeAcc, string PayInfoPassw)
        {
            return DAL.PayInfoDataAccess.PayInfoUpdate(PayInfoUserAcc, PayInfoCodeAcc, PayInfoPassw);
        }

        /// <summary>
        /// 根据用户帐号和卡号修改余额,支出
        /// </summary>
        /// <param name="UserAcc1">用户账号</param>
        /// <param name="CodeAcc1">用户支付账号</param>
        /// <param name="UserAcc2">员工账号</param>
        /// <param name="CodeAcc2">员工支付账号</param>
        /// <param name="money">转账金额</param>
        /// <returns></returns>
        public static bool PayInfoUpdateBlackFigurepay(string UserAcc1, string CodeAcc1, string UserAcc2, string CodeAcc2, float money)
        {
            return DAL.PayInfoDataAccess.PayInfoUpdateBlackFigurepay(UserAcc1, CodeAcc1, UserAcc2, CodeAcc2, money);
        }
    }
}
