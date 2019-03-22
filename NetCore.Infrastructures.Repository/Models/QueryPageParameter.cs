using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructures.Repository.Models
{
    /// <summary>
    /// 分页查询参数
    /// </summary>
    public class QueryPageParameter
    {
        /// <summary>
        /// 查询字段
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// sql语句
        /// </summary>
        public string FromSql { get; set; }

        /// <summary>
        /// 分组字段
        /// </summary>
        public string GroupBy { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 当前页下标
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// 每页数据条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 查询参数
        /// </summary>
        public object Param { get; set; }
    }
}
