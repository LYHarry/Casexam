using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo
    {
        public UserInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 用户表编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public string UserSex { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string UserCertificate { get; set; }

        /// <summary>
        /// 用户联系电话
        /// </summary>
        public string UserTel { get; set; }

        /// <summary>
        /// 用户电子邮箱地址
        /// </summary>
        public string UserEmail { get; set; }      

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }

        /// <summary>
        /// 用户联系地址
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 用户创建时间
        /// </summary>
        public DateTime UserSetting { get; set; }
    }
}
