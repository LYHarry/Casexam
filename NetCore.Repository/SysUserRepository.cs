using NetCore.Entity;
using NetCore.Infrastructures.Repository;
using NetCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Repository
{
    /// <summary>
    /// 系统管理员用户数据仓储类
    /// </summary>
    public class SysUserRepository : Repository<SysUserEntity, int>, ISysUserRepository
    {
        public SysUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
