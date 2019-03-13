using Rpc.Infrastructures.Server;
using Rpc.Model.SysUser;
using Rpc.ViewModel;
using Rpc.ViewModel.SysUser;
using System.Threading.Tasks;

namespace Rpc.UserServer.Interface
{
    /// <summary>
    /// 系统管理员用户业务处理接口类
    /// </summary>
    public interface ISysUserService : IService
    {
        Task<bool> Add(AddRequest request);

        Task<PagedResult<GetListResult>> List(GetListRequest request);

        Task<bool> Update(UpdateRequest request);

        Task<bool> ModifyPassword(ModifyPasswordRequest request);

        Task<bool> Login(LoginRequest request);

        Task<bool> Delete(int id);
    }
}
