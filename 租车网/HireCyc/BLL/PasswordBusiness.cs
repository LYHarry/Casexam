using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    ///  加密信息表DAL
    /// </summary>
    public class PasswordBusiness
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="pass"></param>
        /// <returns>bool值</returns>
        public static bool PasswordAdd(string ueername, string kept)
        {
            return DAL.PasswordDataAccess.PasswordAdd(ueername, kept);
        }

        /// <summary>
        /// 根据用户帐号删除数据
        /// </summary>
        /// <param name="Account">用户帐号</param>
        /// <returns>bool值</returns>
        public static bool PasswordDelByAccount(string Account)
        {
            return DAL.PasswordDataAccess.PasswordDelByAccount(Account);
        }

        /// <summary>
        /// 根据帐号查询密码
        /// </summary>
        /// <param name="Account">帐号</param>
        /// <returns>string值，密码</returns>
        public static string PasswordLookpassByAccount(string Account)
        {
            return DAL.PasswordDataAccess.PasswordLookpassByAccount(Account);
        }

        /// <summary>
        /// 根据帐号，修改加密信息
        /// </summary>
        /// <param name="uername">用户账号</param>
        /// <param name="keyt">新密码</param>
        /// <returns></returns>
        public static bool PasswordUpdateByAccount(string ueername, string kept)
        {
            return DAL.PasswordDataAccess.PasswordUpdateByAccount(ueername, kept);
        }



        /// <summary>
        /// 查询所有密钥
        /// </summary>
        /// <returns></returns>
        public static List<string> PasswordLookALLPaw()
        {
            return DAL.PasswordDataAccess.PasswordLookALLPaw();
        }

    }
}
