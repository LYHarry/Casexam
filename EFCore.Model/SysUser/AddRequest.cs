using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model.SysUser
{
    /// <summary>
    /// 添加系统管理员用户请求参数
    /// </summary>
    public class AddRequest
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }

    }
}
