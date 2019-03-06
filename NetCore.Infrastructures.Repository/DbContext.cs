using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NetCore.Infrastructures.Repository
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DbContext : IDbContext
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _dbTransaction;

        public DbContext(IUnitOfWork unitOfWork)
        {
            _dbConnection = unitOfWork.GetDbConnection();
            _dbTransaction = unitOfWork.GeTransaction();
        }

        public Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetListAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            throw new NotImplementedException();
        }

        public Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            throw new NotImplementedException();
        }
    }
}
