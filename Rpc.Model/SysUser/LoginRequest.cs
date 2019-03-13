using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Model.SysUser
{
    /// <summary>
    /// 系统管理员用户登陆请求参数
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerCode { get; set; }
    }
}
