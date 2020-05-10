using Dapper;
using NetCore.Infrastructures.Repository.Models;
using NetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Infrastructures.Repository
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryParameter"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<PagedResult<T>> GetPagedAsync<T>(QueryPageParameter queryParameter, int? commandTimeout = null);
    }
}
