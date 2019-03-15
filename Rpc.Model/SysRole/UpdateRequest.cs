﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Model.SysRole
{
    /// <summary>
    /// 更新系统角色请求参数
    /// </summary>
    public class UpdateRequest : AddRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
    }
}