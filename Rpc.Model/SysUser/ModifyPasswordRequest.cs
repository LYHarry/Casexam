using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Model.SysUser
{
    /// <summary>
    /// 修改系统管理员用户密码请求参数
    /// </summary>
    public class ModifyPasswordRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
    }
}
