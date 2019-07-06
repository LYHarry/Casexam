using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Music.Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class Users
    {
        private int id;  //用户编号
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string userName;  //用户名称
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;  //密码
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string email;  //电子邮箱
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime registerTime; 	//注册时间
        public DateTime RegisterTime
        {
            get { return registerTime; }
            set { registerTime = value; }
        }

        private int role;	//用户角色
        public int Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
