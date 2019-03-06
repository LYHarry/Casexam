using Dapper;
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
        #region 查询单个

        Task<T> GetAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion

        #region 获取列表

        Task<IEnumerable<T>> GetListAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        //Task<PagedList<T>> GetPagedAsync<T>(QueryPageParameter queryParameter, int? commandTimeout = null,
        //    CommandType? commandType = null);

        #endregion

        #region 执行sql返回多个结果集

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion

        #region 执行sql

        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        #endregion
    }
}
