using Rpc.Infrastructures.Repository.Models;
using Rpc.ViewModel;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Repository
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
