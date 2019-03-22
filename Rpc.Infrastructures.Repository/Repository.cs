using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Repository
{
    /// <summary>
    /// 基类仓储
    /// </summary>
    /// <typeparam name="TEntity">实体对象</typeparam>
    /// <typeparam name="TKey">实体主键</typeparam>
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public Repository(IUnitOfWork unitOfWork)
        {
            _connection = unitOfWork.GetDbConnection();
            _transaction = unitOfWork.GeTransaction();
        }

        public Task<int> DeleteAsync(TKey id)
        {
            return _connection.DeleteAsync<TEntity>(id, _transaction);
        }

        public async Task<bool> ExsitsAsync(string conditions, object parameters = null)
        {
            return await _connection.RecordCountAsync<TEntity>(conditions, parameters, _transaction) > 0;
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return _connection.GetAsync<TEntity>(id, _transaction);
        }

        public Task<TEntity> GetAsync(string sql, object param = null)
        {
            var result = _connection.GetList<TEntity>(sql, param, _transaction).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<TKey> InsertAsync(TEntity entity)
        {
            return _connection.InsertAsync<TKey, TEntity>(entity, _transaction);
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            return _connection.UpdateAsync(entity, _transaction);
        }

    }

}
