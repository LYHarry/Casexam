using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserInfoBusiness
    {
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="username">用户账号</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        public static bool AddUserInfo(string username, string password)
        {
            return DAL.UserInfoDataAccess.AddUserInfo(username, password);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserAccount">要删除的用户的账号</param>
        /// <returns></returns>
        public static bool DeteleUserInfo(string UserAccount)
        {
            return DAL.UserInfoDataAccess.DeteleUserInfo(UserAccount);
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="UserAccount">想更改你用户名</param>
        /// <param name="newPassword">更改的新密码</param>
        /// <returns></returns>
        public static bool ChangeUserPassword(string UserAccount, string newPassword)
        {
            return DAL.UserInfoDataAccess.ChangeUserPassword(UserAccount, newPassword);
        }

        /// <summary>
        /// 更改用户所有信息，密码除外
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool ChangeAll(Model.UserInfo userInfo)
        {
            return DAL.UserInfoDataAccess.ChangeAll(userInfo);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserAccount">用户用户名</param>
        /// <param name="UserPassword">用户的密码</param>
        /// <returns></returns>
        public static bool UserLogin(string UserAccount, string UserPassword)
        {
            return DAL.UserInfoDataAccess.UserLogin(UserAccount, UserPassword);
        }

        /// <summary>
        /// 获取指定的用户信息
        /// </summary>
        /// <param name="?">想要获取的用户名</param>
        /// <returns></returns>
        public static List<Model.UserInfo> userInfo(string UserAccount)
        {
            return DAL.UserInfoDataAccess.userInfo(UserAccount);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static List<Model.UserInfo> GetAllUsers()
        {
            return DAL.UserInfoDataAccess.GetAllUsers();
        }

        /// <summary>
        /// 通过用户昵称得到登录名
        /// </summary>
        /// <param name="UserNickName"></param>
        /// <returns></returns>
        public static string GetAccountByUserNickName(string UserNickName)
        {
            return DAL.UserInfoDataAccess.GetAccountByUserNickName(UserNickName);
        }

        /// <summary>
        /// 判断指定的用户账号是否存在
        /// </summary>
        /// <param name="account">要判断的账号</param>
        /// <returns></returns>
        public static bool UserInfoLookAccount(string account)
        {
            return DAL.UserInfoDataAccess.UserInfoLookAccount(account);
        }

        /// <summary>
        /// 判断指定的用户的身份证号是否存在
        /// </summary>
        /// <param name="account">要判断的账号</param>
        /// <returns></returns>
        public static bool UserInfoLookCer(string account)
        {
            return DAL.UserInfoDataAccess.UserInfoLookCer(account);
        }

        /// <summary>
        /// 更改用户邮箱
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="email">新邮箱</param>
        /// <returns></returns>
        public static bool UpdateEmail(string UserAccount, string email)
        {
            return DAL.UserInfoDataAccess.UpdateEmail(UserAccount, email);
        }

        /// <summary>
        /// 更改用户昵称
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="nickName">新昵称</param>
        /// <returns></returns>
        public static bool UpdateNickName(string UserAccount, string nickName)
        {
            return DAL.UserInfoDataAccess.UpdateNickName(UserAccount, nickName);
        }

        /// <summary>
        /// 更改用户联系方式
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="tel">新的电话号码</param>
        /// <returns></returns>
        public static bool UpdateTel(string UserAccount, string tel)
        {
            return DAL.UserInfoDataAccess.UpdateTel(UserAccount, tel);
        }


        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.UserInfo> UserInfoFeny(int ys, int count)
        {
            return DAL.UserInfoDataAccess.UserInfoFeny(ys, count);
        }

        /// <summary>
        /// 分页，根据每页的条数，计算总页数
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值</returns>
        public static int UserInfoYs(int count)
        {
            return DAL.UserInfoDataAccess.UserInfoYs(count);
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="acc">用户账号</param>
        /// <param name="stream">图片流</param>
        /// <returns></returns>
        public static bool UpdatePhoto(string acc, Stream stream)
        {
            return DAL.UserInfoDataAccess.UpdatePhoto(acc, stream);
        }
    }

}
