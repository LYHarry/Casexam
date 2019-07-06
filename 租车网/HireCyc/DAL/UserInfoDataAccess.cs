using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace DAL
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class UserInfoDataAccess
    {
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="username">用户账号</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        public static bool AddUserInfo(string username, string password)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Account",username),
                new SqlParameter("@Password",password)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserAccount">要删除的用户的账号</param>
        /// <returns></returns>
        public static bool DeteleUserInfo(string UserAccount)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                   new SqlParameter("@Account",UserAccount)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="UserAccount">想更改你用户名</param>
        /// <param name="newPassword">更改的新密码</param>
        /// <returns></returns>
        public static bool ChangeUserPassword(string UserAccount, string newPassword)
        {
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@Account",UserAccount),
               new SqlParameter("@Password",newPassword)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoUpdatePass", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 更改用户所有信息，密码除外
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool ChangeAll(Model.UserInfo userInfo)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Account",userInfo.UserAccount),
                new SqlParameter("@Name",userInfo.UserName),
                new SqlParameter("@Sex",userInfo.UserSex),
                new SqlParameter("@tel",userInfo.UserTel),
                new SqlParameter("@Certificate",userInfo.UserCertificate),
                new SqlParameter("@Address",userInfo.UserAccount),
                new SqlParameter("@email",userInfo.UserEmail),
                new SqlParameter("@NickName",userInfo.UserNickName)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoUpdateBase", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserAccount">用户用户名</param>
        /// <param name="UserPassword">用户的密码</param>
        /// <returns></returns>
        public static bool UserLogin(string UserAccount, string UserPassword)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",UserAccount),
              new SqlParameter("@Password",UserPassword)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("UserInfoDengLu", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 获取指定的用户信息
        /// </summary>
        /// <param name="?">想要获取的用户名</param>
        /// <returns></returns>
        public static List<Model.UserInfo> userInfo(string UserAccount)
        {
            List<Model.UserInfo> list = new List<Model.UserInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",UserAccount)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("UserInfoLookByAccount", CommandType.StoredProcedure, p);

            while (sdr.Read())
            {
                Model.UserInfo userInfo = new Model.UserInfo();//创建一个User对象

                userInfo.UserName = Convert.ToString(sdr["姓名"]);
                userInfo.UserSex = Convert.ToString(sdr["性别"]);
                userInfo.UserCertificate = Convert.ToString(sdr["身份证号"]);
                userInfo.UserTel = Convert.ToString(sdr["电话"]);
                userInfo.UserEmail = Convert.ToString(sdr["邮箱"]);
                userInfo.UserNickName = Convert.ToString(sdr["昵称"]);
                userInfo.UserAddress = Convert.ToString(sdr["地址"]);

                list.Add(userInfo);
            }
            return list;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static List<Model.UserInfo> GetAllUsers()
        {
            List<Model.UserInfo> list = new List<Model.UserInfo>();//创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("UserInfoLookALL", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.UserInfo userInfo = new Model.UserInfo();

                userInfo.UserAccount = Convert.ToString(sdr["账号"]);
                userInfo.UserName = Convert.ToString(sdr["姓名"]);
                userInfo.UserSex = Convert.ToString(sdr["性别"]);
                userInfo.UserCertificate = Convert.ToString(sdr["身份证号"]);
                userInfo.UserTel = Convert.ToString(sdr["电话"]);
                userInfo.UserEmail = Convert.ToString(sdr["邮箱"]);
                userInfo.UserNickName = Convert.ToString(sdr["昵称"]);
                userInfo.UserAddress = Convert.ToString(sdr["地址"]);
                userInfo.UserSetting = Convert.ToDateTime(sdr["注册时间"]);
                list.Add(userInfo);
            }
            return list;
        }

        /// <summary>
        /// 通过用户昵称得到登录名
        /// </summary>
        /// <param name="UserNickName"></param>
        /// <returns></returns>
        public static string GetAccountByUserNickName(string UserNickName)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@NickName",UserNickName)
             };
            string account = (SQLHelper.ExecuteScalar("UserInfoLookAccountByNickName", CommandType.StoredProcedure, p)).ToString();
            return account;
        }

        /// <summary>
        /// 判断指定的用户账号是否存在
        /// </summary>
        /// <param name="account">要判断的账号</param>
        /// <returns></returns>
        public static bool UserInfoLookAccount(string account)
        {
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@UserAcc",account)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("userInfoAccountIsExist", CommandType.StoredProcedure, p));

            return f == 1;  //为真表示存在
        }

        /// <summary>
        /// 判断指定的用户的身份证号是否存在
        /// </summary>
        /// <param name="account">要判断的账号</param>
        /// <returns></returns>
        public static bool UserInfoLookCer(string account)
        {
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@UserAcc",account)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("userInfoCertificateIsNull", CommandType.StoredProcedure, p));

            return f == 1;  //为真表示存在
        }


        /// <summary>
        /// 更改用户邮箱
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="email">新邮箱</param>
        /// <returns></returns>
        public static bool UpdateEmail(string UserAccount, string email)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",UserAccount),
              new SqlParameter("@Email",email)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoUpdateEmail", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 更改用户昵称
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="nickName">新昵称</param>
        /// <returns></returns>
        public static bool UpdateNickName(string UserAccount, string nickName)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",UserAccount),
              new SqlParameter("@NickName",nickName)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoUpdateNickName", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 更改用户联系方式
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="tel">新的电话号码</param>
        /// <returns></returns>
        public static bool UpdateTel(string UserAccount, string tel)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",UserAccount),
              new SqlParameter("@Tel",tel)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoUpdateTel", CommandType.StoredProcedure, p));
            return i > 0;
        }


        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.UserInfo> UserInfoFeny(int ys, int count)
        {
            List<Model.UserInfo> list = new List<Model.UserInfo>();//创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@ys",ys),
               new SqlParameter("@count",count)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("UserInfoFeny", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                userInfo.UserId = Convert.ToInt32(sdr["编号"]);
                userInfo.UserAccount = Convert.ToString(sdr["账号"]);
                userInfo.UserName = Convert.ToString(sdr["姓名"]);
                userInfo.UserSex = Convert.ToString(sdr["性别"]);
                userInfo.UserCertificate = Convert.ToString(sdr["身份证号"]);
                userInfo.UserTel = Convert.ToString(sdr["电话"]);
                userInfo.UserEmail = Convert.ToString(sdr["邮箱"]);
                userInfo.UserNickName = Convert.ToString(sdr["昵称"]);
                userInfo.UserAddress = Convert.ToString(sdr["地址"]);
                list.Add(userInfo);
            }
            return list;
        }

        /// <summary>
        /// 分页，根据每页的条数，计算总页数
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值</returns>
        public static int UserInfoYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@count",count)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("UserInfoYs", CommandType.StoredProcedure, p));
            return i;
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="acc">用户账号</param>
        /// <param name="stream">图片流</param>
        /// <returns></returns>
        public static bool UpdatePhoto(string acc, Stream stream)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",acc),
              new SqlParameter("@img",stream)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("UserInfoUpdatePhoto", CommandType.StoredProcedure, p));
            return i > 0;
        }
    }

}

