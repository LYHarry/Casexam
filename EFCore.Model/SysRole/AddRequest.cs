using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model.SysRole
{
    /// <summary>
    /// 添加系统角色请求参数
    /// </summary>
    public class AddRequest
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
