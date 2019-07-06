using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Music.DAL
{
    /// <summary>
    /// Users的数据访问类，处理和Users有关的数据库访问的相关的操作
    /// </summary>
    public class UserDataAccess
    {
        /// <summary>
        /// 判断指定的用户名是否存在
        /// </summary>
        /// <param name="userName">要判断的用户名</param>
        /// <returns>返回是否判断成功</returns>
        public static bool UserIsExist(string userName)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName)
            };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("UserIsExist", CommandType.StoredProcedure, par));
            return f > 0;
        }

        /// <summary>
        /// 添加User(用户)对象
        /// </summary>
        /// <param name="user">要添加的User对象</param>
        /// <returns>返回是否成功添加</returns>
        public static bool AddUser(Music.Model.Users user)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@Password",user.Password),
                new SqlParameter("@Email",user.Email),
                new SqlParameter("@RegisterTime",user.RegisterTime), 
                new SqlParameter("@Role",user.Role)
            };
            int f = SQLHelper.ExecuteNonQuery("AddUser", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 删除User对象
        /// </summary>
        /// <param name="id">要删除User对象的ID</param>
        /// <returns>返回是否成功删除</returns>
        public static bool DeleteUser(int id)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            int f = SQLHelper.ExecuteNonQuery("DeleteUser", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">要更改用户的ID</param>
        /// <param name="newPassword">更改的新密码</param>
        /// <returns></returns>
        public static bool ChangePassword(int id, string newPassword)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@newPassword",newPassword)
            };
            int f = SQLHelper.ExecuteNonQuery("ChangePassword", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户的用户名</param>
        /// <param name="Password">用户的密码</param>
        /// <returns></returns>
        public static bool UserLogin(string userName, string password)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",password)
            };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("UserLogin", CommandType.StoredProcedure, par));
            return f > 0;
        }

        /// <summary>
        /// 获取指定的用户
        /// </summary>
        /// <param name="id">要获取用户的ID</param>
        /// <returns></returns>
        public static Music.Model.Users GetUser(int id)
        {
            Music.Model.Users user = new Model.Users();  //创建一个User对象

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetUser", CommandType.StoredProcedure, par);
            if (sdr.Read())
            {
                user.ID = Convert.ToInt32(sdr["ID"]);
                user.UserName = Convert.ToString(sdr["UserName"]);
                user.Password = Convert.ToString(sdr["Password"]);
                user.RegisterTime = Convert.ToDateTime(sdr["RegisterTime"]);
                user.Role = Convert.ToInt32(sdr["Role"]);
                user.Email = Convert.ToString(sdr["Email"]);
            }
            return user;
        }

        /// <summary>
        /// 获取所有的用户对象
        /// </summary>
        /// <returns></returns>
        public static List<Music.Model.Users> GetAllUsers()
        {
            List<Music.Model.Users> list = new List<Model.Users>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetAllUsers", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Music.Model.Users user = new Model.Users();
                user.ID = Convert.ToInt32(sdr["ID"]);
                user.UserName = Convert.ToString(sdr["UserName"]);
                user.Password = Convert.ToString(sdr["Password"]);
                user.RegisterTime = Convert.ToDateTime(sdr["RegisterTime"]);
                user.Role = Convert.ToInt32(sdr["Role"]);
                user.Email = Convert.ToString(sdr["Email"]);

                list.Add(user);
            }
            return list;
        }

        /// <summary>
        /// 获取最近注册用户列表
        /// </summary>
        /// <param name="count">获取最近注册用户的个数</param>
        /// <returns></returns>
        public static List<Music.Model.Users> GetNewUsers(int count)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@count",count)
            };

            List<Music.Model.Users> list = new List<Model.Users>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetNewUsers", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                Music.Model.Users user = new Model.Users();
                user.ID = Convert.ToInt32(sdr["ID"]);
                user.UserName = Convert.ToString(sdr["UserName"]);
                user.Password = Convert.ToString(sdr["Password"]);
                user.RegisterTime = Convert.ToDateTime(sdr["RegisterTime"]);
                user.Role = Convert.ToInt32(sdr["Role"]);
                user.Email = Convert.ToString(sdr["Email"]);

                list.Add(user);
            }
            return list;
        }

        /// <summary>
        /// 获取歌曲对应的用户
        /// </summary>
        /// <param name="id">歌曲的ID</param>
        /// <returns></returns>
        public static Music.Model.Users GetUserBySong(int id)
        {
            Music.Model.Users user = new Model.Users();  //创建一个User对象

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetUserBySong", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                user.ID = Convert.ToInt32(sdr["ID"]);
                user.UserName = Convert.ToString(sdr["UserName"]);
                user.Password = Convert.ToString(sdr["Password"]);
                user.RegisterTime = Convert.ToDateTime(sdr["RegisterTime"]);
                user.Role = Convert.ToInt32(sdr["Role"]);
                user.Email = Convert.ToString(sdr["Email"]);
            }
            return user;
        }

        /// <summary>
        /// 通过用户名得到用户ID
        /// </summary>
        /// <param name="userName">用户的ID</param>
        /// <returns></returns>
        public static int GetUserIDByUserName(string userName)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@userName",userName)
            };
            int id = Convert.ToInt32(SQLHelper.ExecuteScalar("GetUserIDByUserName", CommandType.StoredProcedure, par));

            return id;
        }

    }
}
