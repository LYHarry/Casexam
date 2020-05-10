using NetCore.Models.SysRole;
using NetCore.ViewModels;
using NetCore.ViewModels.SysRole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Interface
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
    }
}
