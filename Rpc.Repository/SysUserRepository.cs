﻿using Rpc.Entity;
using Rpc.Infrastructures.Repository;
using Rpc.Repository.Interface;

namespace Rpc.Repository
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
