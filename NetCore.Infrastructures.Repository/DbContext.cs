using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetCore.Infrastructures.Repository.Models;
using NetCore.ViewModels;

namespace NetCore.Infrastructures.Repository
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

        public async Task<PagedResult<T>> GetPagedAsync<T>(QueryPageParameter queryParameter, int? commandTimeout = null)
        {
            if (string.IsNullOrWhiteSpace(queryParameter.Field))
                throw new ArgumentException("Field is not null");
            if (string.IsNullOrWhiteSpace(queryParameter.FromSql))
                throw new ArgumentException("FromSql is not null");
            StringBuilder strsql = new StringBuilder();
            strsql.Append($"SELECT COUNT(1) FROM {queryParameter.FromSql}; ");
            if (!string.IsNullOrWhiteSpace(queryParameter.GroupBy))
            {
                strsql.Clear();
                strsql.Append($"SELECT COUNT(1) FROM ");
                strsql.Append($"(SELECT {queryParameter.Field} FROM {queryParameter.FromSql} {queryParameter.GroupBy})");
                strsql.Append(" t1; ");
            }
            strsql.Append($" SELECT {queryParameter.Field} FROM {queryParameter.FromSql} {queryParameter.GroupBy}");
            strsql.Append($" ORDER BY {queryParameter.OrderBy}");
            strsql.Append($" LIMIT {queryParameter.PageSize}");
            strsql.Append($" OFFSET {(queryParameter.PageNumber - 1) * queryParameter.PageSize} ;");
            var result = await _connection.QueryMultipleAsync(strsql.ToString(), queryParameter.Param, _transaction, commandTimeout);
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
