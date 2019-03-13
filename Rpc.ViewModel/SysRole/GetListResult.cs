using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.ViewModel.SysRole
{
    /// <summary>
    /// 系统角色分页列表返回参数
    /// </summary>
    public class GetListResult
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
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
