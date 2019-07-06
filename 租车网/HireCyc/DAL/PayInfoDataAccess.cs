using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 用户支付信息表（账户表）
    /// </summary>
    public class PayInfoDataAccess
    {
        /// <summary>
        /// 添加支付信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool PayInfoAdd(Model.PayInfo payInfo)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@UserAcc",payInfo.PayInfoUserAcc),
                new SqlParameter("@Type",payInfo.PayInfoType),
                new SqlParameter("@CodeAcc",payInfo.PayInfoCodeAcc),
                new SqlParameter("@Passw",payInfo.PayInfoPassw),
                new SqlParameter("@BlackFigure",payInfo.PayInfoBlackFigure)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PayInfoAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 判断某用户的支付宝或银行卡号是否为空
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <returns></returns>
        public static bool payInfoCodeAccIsExist(string PayInfoUserAcc)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@UserAcc",PayInfoUserAcc)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("payInfoCodeAccIsNull", CommandType.StoredProcedure, p));
            return i > 0;  //为真表示存在，不为空
        }

        /// <summary>
        /// 根据用户账号和卡号删除数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool PayInfoDel(string PayInfoUserAcc, string PayInfoCodeAcc)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@UserAcc",PayInfoUserAcc),
                new SqlParameter("@CodeAcc",PayInfoCodeAcc)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PayInfoDel", CommandType.StoredProcedure, p));
            return i > 0;
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
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@UserAcc",PayInfoUserAcc),
                new SqlParameter("@CodeAcc",PayInfoCodeAcc),
                new SqlParameter("@password",codeAccPaw)
            };

            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("PayInfoLookByUserAccAndCodeAcc", CommandType.StoredProcedure, p));

            return f == 1;
        }

        /// <summary>
        /// 根据用户账号和卡号查询支付余额
        /// </summary>
        /// <param name="PayInfoUserAcc"></param>
        /// <param name="PayInfoCodeAcc"></param>
        /// <returns></returns>
        public static float PayInfoLookMoney(string PayInfoUserAcc, string PayInfoCodeAcc)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@UserAcc",PayInfoUserAcc),
               new SqlParameter("@CodeAcc",PayInfoCodeAcc)
            };
            float PayInfoBlackFigure = Convert.ToSingle(SQLHelper.ExecuteScalar("PayInfoLookMoneyByUserAccAndCodeAcc", CommandType.StoredProcedure, p));

            return PayInfoBlackFigure;
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
            SqlParameter[] p = new SqlParameter[]
             {
                 new SqlParameter("@UserAcc",PayInfoUserAcc),
                 new SqlParameter("@CodeAcc",PayInfoCodeAcc),
                 new SqlParameter("@Passw",PayInfoPassw)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PayInfoUpdate", CommandType.StoredProcedure, p));
            return i > 0;
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
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@UserAcc1",UserAcc1),
                new SqlParameter("@CodeAcc1",CodeAcc1),
                new SqlParameter("@UserAcc2",UserAcc2),
                new SqlParameter("@CodeAcc2",@CodeAcc2),
                new SqlParameter("@m",money)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("PayInfoUpdateBlackFigurepay", CommandType.StoredProcedure, p));
            return i > 0;
        }

    }
}
