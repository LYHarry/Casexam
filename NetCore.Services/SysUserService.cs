using NetCore.Entity;
using NetCore.Infrastructures.Extensions;
using NetCore.Infrastructures.Repository;
using NetCore.Infrastructures.Repository.Models;
using NetCore.Models.SysUser;
using NetCore.Repository.Interface;
using NetCore.Services.Interface;
using NetCore.ViewModels;
using NetCore.ViewModels.SysUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services
{
    /// <summary>
    /// 系统管理员用户业务处理类
    /// </summary>
    public class SysUserService : ISysUserService
    {
        private readonly ISysUserRepository _sysUserRepository;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly IDbContext _dbContext;

        public SysUserService(ISysUserRepository sysUser, ISysRoleRepository sysRole, IDbContext dbContext)
        {
            _sysUserRepository = sysUser;
            _sysRoleRepository = sysRole;
            _dbContext = dbContext;
        }

        public async Task<bool> Add(AddRequest request)
        {
            var isExsit = await _sysUserRepository.ExsitsAsync("where Account=@acct", new { acct = request.Account });
            if (isExsit)
                throw new Exception("此账号已存在");
            isExsit = await _sysRoleRepository.ExsitsAsync("where ID=@id", new { id = request.RoleID });
            if (!isExsit)
                throw new Exception("账号所属角色不存在");

            var userEntity = request.MapTo<SysUserEntity>();
            userEntity.Status = 1;
            userEntity.CreateDate = DateTime.Now;
            var row = await _sysUserRepository.InsertAsync(userEntity);
            return row > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var row = await _sysUserRepository.DeleteAsync(id);
            return row > 0;
        }

        public async Task<PagedResult<GetListResult>> List(GetListRequest request)
        {
            StringBuilder sbstr = new StringBuilder();
            sbstr.Append("FROM sysuser u LEFT JOIN sysrole r on u.roleid=r.ID");
            sbstr.Append("WHERE u.\"Status\"=1 AND r.\"Status\"=1");
            var query = new QueryPageParameter
            {
                Field = " u.*,r.\"Name\"  AS RoleName ",
                FromSql = sbstr.ToString(),
                OrderBy = "u.\"CreateDate\" DESC",
                PageNumber = request.PageIndex,
                PageSize = request.PageSize,
            };
            var result = await _dbContext.GetPagedAsync<GetListResult>(query);
            return result;
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var userEntity = await _sysUserRepository.GetAsync("where Account=@acct", new { acct = request.Account });
            if (userEntity == null)
                throw new Exception("此账号不存在");
            if (userEntity.Password != request.Password)
                throw new Exception("密码错误");

            return true;
        }

        public async Task<bool> ModifyPassword(ModifyPasswordRequest request)
        {
            if (request.OldPassword == request.NewPassword)
                throw new Exception("新旧密码不能一样");
            var userEntity = await _sysUserRepository.GetAsync(request.ID);
            if (userEntity == null)
                throw new Exception("此账号不存在");
            if (userEntity.Password != request.OldPassword)
                throw new Exception("旧密码错误");
            if (userEntity.Password == request.NewPassword)
                throw new Exception("新旧密码不能一样");

            userEntity.Password = request.NewPassword;
            var row = await _sysUserRepository.UpdateAsync(userEntity);
            return row > 0;
        }

        public async Task<bool> Update(UpdateRequest request)
        {
            var userEntity = await _sysUserRepository.GetAsync(request.ID);
            if (userEntity == null)
                throw new Exception("此账号不存在");

            userEntity.Name = request.Name;
            userEntity.RoleID = request.RoleID;
            var row = await _sysUserRepository.UpdateAsync(userEntity);
            return row > 0;
        }
    }
}
