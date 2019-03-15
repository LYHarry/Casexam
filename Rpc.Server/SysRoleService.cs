﻿using NetCore.Infrastructures.Extensions;
using Rpc.Entity;
using Rpc.Infrastructures.Repository;
using Rpc.Infrastructures.Repository.Models;
using Rpc.Model.SysRole;
using Rpc.Repository.Interface;
using Rpc.Server.Interface;
using Rpc.ViewModel;
using Rpc.ViewModel.SysRole;
using System;
using System.Threading.Tasks;

namespace Rpc.Server
{
    /// <summary>
    /// 系统角色业务处理类
    /// </summary>
    public class SysRoleService : ISysRoleService
    {
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly IDbContext _dbContext;

        public SysRoleService(ISysRoleRepository sysRole, IDbContext dbContext)
        {
            _sysRoleRepository = sysRole;
            _dbContext = dbContext;
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

        public async Task<PagedResult<GetListResult>> List(GetListRequest request)
        {
            var query = new QueryPageParameter
            {
                Field = " * ",
                FromSql = "sysrole WHERE \"Status\"=1 ",
                OrderBy = "\"CreateDate\" DESC",
                PageNumber = request.PageIndex,
                PageSize = request.PageSize,
            };
            var result = await _dbContext.GetPagedAsync<GetListResult>(query);
            return result;
        }

        public async Task<bool> Update(UpdateRequest request)
        {
            var roleEntity = await _sysRoleRepository.GetAsync(request.ID);
            if (roleEntity == null)
                throw new Exception("不存在该系统角色");

            var requestEntity = request.MapTo<SysRoleEntity>();
            requestEntity.Status = roleEntity.Status;
            requestEntity.CreateDate = roleEntity.CreateDate;
            var row = await _sysRoleRepository.UpdateAsync(requestEntity);
            return row > 0;
        }

        public async Task<bool> NoArguments()
        {
            return await Task.FromResult(true);
        }
    }
}
