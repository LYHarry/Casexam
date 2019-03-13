using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Rpc.Infrastructures.Repository
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 事务提交
        /// </summary>
        void Commit();

        /// <summary>
        /// 事务回滚
        /// </summary>
        void Rollback();

        /// <summary>
        /// 得到数据库连接对象
        /// </summary>
        /// <returns></returns>
        IDbConnection GetDbConnection();

        /// <summary>
        /// 得到数据库事务对象
        /// </summary>
        /// <returns></returns>
        IDbTransaction GeTransaction();
    }
}
