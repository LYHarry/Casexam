using Rpc.Entity;
using Rpc.Infrastructures.Repository;

namespace Rpc.Repository.Interface
{
    /// <summary>
    /// 系统角色数据仓储接口类
    /// </summary>
    public interface ISysRoleRepository : IRepository<SysRoleEntity, int>, IDbService
    {

    }
}
