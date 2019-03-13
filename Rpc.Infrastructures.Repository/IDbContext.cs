using Rpc.Infrastructures.Repository.Models;
using Rpc.ViewModel;
using System.Data;
using System.Threading.Tasks;

namespace Rpc.Infrastructures.Repository
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public interface IDbContext
    {
        Task<PagedResult<T>> GetPagedAsync<T>(QueryPageParameter queryParameter, int? commandTimeout = null, CommandType? commandType = null);

        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

    }
}
