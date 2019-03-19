using EFCore.Model.SysUser;
using EFCore.ViewModel;
using EFCore.ViewModel.SysUser;
using System.Threading.Tasks;

namespace EFCore.Service.Interface
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
