using Rpc.Entity;
using Rpc.Infrastructures.Repository;

namespace Rpc.Repository.Interface
{
    /// <summary>
    /// 系统管理员用户数据仓储接口类
    /// </summary>
    public interface ISysUserRepository : IRepository<SysUserEntity, int>, IDbService
    {

    }
}
