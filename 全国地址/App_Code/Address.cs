using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 全国地址
{
    /// <summary>
    /// 地址类
    /// </summary>
    public class AddressModel
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属省ID
        /// </summary>
        public string ProvID { get; set; }

        /// <summary>
        /// 所属父级ID
        /// </summary>
        public string ParentID { get; set; }

        /// <summary>
        /// 父级Url
        /// </summary>
        public string ParentUrl { get; set; }

        /// <summary>
        /// 子级Url
        /// </summary>
        public string ChildUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}