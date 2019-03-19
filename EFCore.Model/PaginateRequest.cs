using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model
{
    /// <summary>
    /// 分页请求参数基类
    /// </summary>
    public class PaginateRequest
    {
        /// <summary>
        ///  页码
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        ///  分页大小
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
