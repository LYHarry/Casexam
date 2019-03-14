using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Infrastructures.Repository.Models
{
    /// <summary>
    /// 分页列表查询请求参数
    /// </summary>
    public class QueryPageParameter
    {
        public string Field { get; set; }

        public string FromSql { get; set; }

        public string GroupBy { get; set; }

        public string OrderBy { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public object Param { get; set; }
    }
}
