using NetCore.Entity;
using NetCore.Infrastructures.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Repository.Interface
{
    /// <summary>
    /// 系统管理员用户数据仓储接口类
    /// </summary>
    public interface ISysUserRepository : IRepository<SysUserEntity, int>
    {

    }
}
