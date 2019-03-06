using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Infrastructures.Repository
{
    /// <summary>
    /// 基类仓储
    /// </summary>
    /// <typeparam name="TEntity">实体对象</typeparam>
    /// <typeparam name="TKey">实体主键</typeparam>
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TKey id);

        Task<TEntity> GetAsync(string sql, object param = null);

        Task<TKey> InsertAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TKey id);

        Task<bool> ExsitsAsync(string conditions, object parameters = null);

    }

}
