using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Model.SysUser
{
    /// <summary>
    /// 更新系统管理员用户请求参数
    /// </summary>
    public class UpdateRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }
    }
}
