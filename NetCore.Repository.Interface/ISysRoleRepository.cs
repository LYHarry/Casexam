using NetCore.Entity;
using NetCore.Infrastructures.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Repository.Interface
{
    /// <summary>
    /// 系统角色数据仓储接口类
    /// </summary>
    public interface ISysRoleRepository : IRepository<SysRoleEntity, int>, IDbService
    {

    }
}
