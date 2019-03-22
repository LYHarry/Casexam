using Rpc.Entity;
using Rpc.Infrastructures.Repository;
using Rpc.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.Repository
{
    /// <summary>
    /// 系统角色数据仓储类
    /// </summary>
    public class SysRoleRepository : Repository<SysRoleEntity, int>, ISysRoleRepository
    {
        public SysRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
