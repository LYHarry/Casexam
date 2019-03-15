using Rpc.Infrastructures.Server;
using Rpc.Model.SysRole;
using Rpc.ViewModel;
using Rpc.ViewModel.SysRole;
using System.Threading.Tasks;

namespace Rpc.Server.Interface
{
    /// <summary>
    /// 系统角色业务处理类
    /// </summary>
    public interface ISysRoleService : IService
    {
        Task<bool> Add(AddRequest request);

        Task<PagedResult<GetListResult>> List(GetListRequest request);

        Task<bool> Update(UpdateRequest request);

        Task<bool> Delete(int id);

        Task<bool> NoArguments();
    }
}
