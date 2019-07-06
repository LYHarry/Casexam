using System.Collections.Generic;

namespace Music.BLL
{
    /// <summary>
    /// User的业务逻辑类
    /// </summary>
    public class UserBusiness
    {
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">要判断的用户名</param>
        /// <returns>返回是否判断成功</returns>
        public static bool UserIsExist(string userName)
        {
            return Music.DAL.UserDataAccess.UserIsExist(userName);
        }

        /// <summary>
        /// 添加User(用户)对象
        /// </summary>
        /// <param name="user">要添加的User对象</param>
        /// <returns>返回是否成功添加</returns>
        public static bool AddUser(Music.Model.Users user)
        {
            return Music.DAL.UserDataAccess.AddUser(user);
        }

        /// <summary>
        /// 删除User对象
        /// </summary>
        /// <param name="id">要删除User对象的ID</param>
        /// <returns>返回是否成功删除</returns>
        public static bool DeleteUser(int id)
        {
            return Music.DAL.UserDataAccess.DeleteUser(id);
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">要更改用户的ID</param>
        /// <param name="newPassword">更改的新密码</param>
        /// <returns></returns>
        public static bool ChangePassword(int id, string newPassword)
        {
            return Music.DAL.UserDataAccess.ChangePassword(id, newPassword);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户的用户名</param>
        /// <param name="Password">用户的密码</param>
        /// <returns></returns>
        public static bool UserLogin(string userName, string password)
        {
            return Music.DAL.UserDataAccess.UserLogin(userName, password);
        }

        /// <summary>
        /// 获取指定的用户
        /// </summary>
        /// <param name="id">要获取用户的ID</param>
        /// <returns></returns>
        public static Music.Model.Users GetUser(int id)
        {
            return Music.DAL.UserDataAccess.GetUser(id);
        }

        /// <summary>
        /// 获取所有的用户对象
        /// </summary>
        /// <returns></returns>
        public static List<Music.Model.Users> GetAllUsers()
        {
            return Music.DAL.UserDataAccess.GetAllUsers();
        }

        /// <summary>
        /// 获取最近注册用户列表
        /// </summary>
        /// <param name="count">获取最近注册用户的个数</param>
        /// <returns></returns>
        public static List<Music.Model.Users> GetNewUsers(int count)
        {
            return Music.DAL.UserDataAccess.GetNewUsers(count);
        }

        /// <summary>
        /// 获取歌曲对应的用户
        /// </summary>
        /// <param name="id">歌曲的ID</param>
        /// <returns></returns>
        public static Music.Model.Users GetUserBySong(int id)
        {
            return Music.DAL.UserDataAccess.GetUserBySong(id);
        }

        /// <summary>
        /// 通过用户名得到用户ID
        /// </summary>
        /// <param name="userName">用户的ID</param>
        /// <returns></returns>
        public static int GetUserIDByUserName(string userName)
        {
            return Music.DAL.UserDataAccess.GetUserIDByUserName(userName);
        }
    }
}
