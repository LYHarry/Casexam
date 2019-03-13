using Dapper;
using Rpc.Infrastructures.Repository.Models;
using Rpc.ViewModel;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Repository
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DbContext : IDbContext
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public DbContext(IUnitOfWork unitOfWork)
        {
            _connection = unitOfWork.GetDbConnection();
            _transaction = unitOfWork.GeTransaction();
        }

        public Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _connection.ExecuteAsync(sql, param, _transaction, commandTimeout, commandType);
        }

        public async Task<PagedResult<T>> GetPagedAsync<T>(QueryPageParameter queryParameter, int? commandTimeout = null, CommandType? commandType = null)
        {
            if (string.IsNullOrWhiteSpace(queryParameter.Field))
                throw new ArgumentException("Field is not null");

            if (string.IsNullOrWhiteSpace(queryParameter.FromSql))
                throw new ArgumentException("FromSql is not null");

            var countSql = $"SELECT COUNT(1) FROM {queryParameter.FromSql};";
            if (!string.IsNullOrWhiteSpace(queryParameter.GroupBy))
                countSql =
                    $"SELECT COUNT(1) FROM (SELECT {queryParameter.Field} FROM {queryParameter.FromSql} {queryParameter.GroupBy})t1;";

            var sql =
                $"{countSql} SELECT {queryParameter.Field} FROM {queryParameter.FromSql} {queryParameter.GroupBy} ORDER BY {queryParameter.OrderBy} OFFSET {(queryParameter.PageNumber - 1) * queryParameter.PageSize} ROWS FETCH NEXT {queryParameter.PageSize} ROWS ONLY;";
            var result = await _connection.QueryMultipleAsync(sql, queryParameter.Param, _transaction, commandTimeout,
                commandType);
            return new PagedResult<T>
            {
                PageIndex = queryParameter.PageNumber,
                PageSize = queryParameter.PageSize,
                TotalItemCount = result.ReadFirst<int>(),
                Items = result.Read<T>().ToList()
            };
        }

    }
}
