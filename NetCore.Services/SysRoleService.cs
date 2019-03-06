using NetCore.Entity;
using NetCore.Infrastructures.Extensions;
using NetCore.Models.SysRole;
using NetCore.Repository.Interface;
using NetCore.Services.Interface;
using NetCore.ViewModels;
using NetCore.ViewModels.SysRole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services
{
    /// <summary>
    /// 系统角色业务处理类
    /// </summary>
    public class SysRoleService : ISysRoleService
    {
        private readonly ISysRoleRepository _sysRoleRepository;

        public SysRoleService(ISysRoleRepository sysRole)
        {
            _sysRoleRepository = sysRole;
        }

        public async Task<bool> Add(AddRequest request)
        {
            var isExsit = await _sysRoleRepository.ExsitsAsync("where \"Name\"=@name", new { name = request.Name });
            if (isExsit)
                throw new Exception("此系统角色已存在");

            var roleEntity = request.MapTo<SysRoleEntity>();
            roleEntity.Status = 1;
            roleEntity.CreateDate = DateTime.Now;
            var row = await _sysRoleRepository.InsertAsync(roleEntity);
            return row > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var row = await _sysRoleRepository.DeleteAsync(id);
            return row > 0;
        }

        public Task<PagedResult<GetListResult>> List(GetListRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(UpdateRequest request)
        {
            var roleEntity = await _sysRoleRepository.GetAsync(request.ID);
            if (roleEntity == null)
                throw new Exception("不存在该系统角色");

            var requestEntity = request.MapTo<SysRoleEntity>();
            requestEntity.Status = roleEntity.Status;
            requestEntity.CreateDate = roleEntity.CreateDate;
            var row = await _sysRoleRepository.UpdateAsync(roleEntity);
            return row > 0;
        }
    }
}
