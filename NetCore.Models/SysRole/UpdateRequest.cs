using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Models.SysRole
{
    /// <summary>
    /// 更新系统角色请求参数
    /// </summary>
    public class UpdateRequest : AddRequest
    {
        public int ID { get; set; }
    }
}
