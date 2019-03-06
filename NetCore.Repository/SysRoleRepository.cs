using NetCore.Entity;
using NetCore.Infrastructures.Repository;
using NetCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Repository
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
