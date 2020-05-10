using NetCore.Models.SysUser;
using NetCore.ViewModels;
using NetCore.ViewModels.SysUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Interface
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
