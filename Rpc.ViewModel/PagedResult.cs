using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.ViewModel
{
    /// <summary>
    /// 数据分页列表结果返回类
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class PagedResult<TItem>
    {
        /// <summary>
        /// 当前页的数据
        /// </summary>
        public IList<TItem> Items { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///  分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///  总条数
        /// </summary>
        public int TotalItemCount { get; set; }

    }
}
