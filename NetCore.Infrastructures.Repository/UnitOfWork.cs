using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Options;
using Npgsql;

namespace NetCore.Infrastructures.Repository
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _dbTransaction;
        private bool _isCommit=false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public UnitOfWork(IOptions<DbConnectionOptions> options)
        {
            var connStr = (options.Value.ConnectionString ?? "").Trim();
            if (string.IsNullOrWhiteSpace(connStr))
                throw new Exception("数据库连接字符串不能为空.");
            switch (options.Value.DbType)
            {
                case DbDialect.PostgreSQL:
                    {
                        _dbConnection = new NpgsqlConnection(connStr);
                    }
                    break;
                case DbDialect.SQLServer:
                    {
                        _dbConnection = new SqlConnection(connStr);
                    }
                    break;
                default:
                    {
                        throw new Exception("数据库类型 DbType 设置错误.");
                    }
            }
            _dbConnection.Open();
            _isCommit = false;
            _dbTransaction = _dbConnection.BeginTransaction();
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void Commit()
        {
            try
            {
                _dbTransaction?.Commit();
                _isCommit = true;
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void Rollback()
        {
            try
            {
                _dbTransaction?.Rollback();
                _isCommit = true;
            }
            catch { throw; }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// 得到数据库连接对象
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetDbConnection()
        {
            return _dbConnection;
        }

        /// <summary>
        /// 得到数据库事务对象
        /// </summary>
        /// <returns></returns>
        public IDbTransaction GeTransaction()
        {
            return _dbTransaction;
        }

        /// <summary>
        /// 销毁数据库连接对象
        /// </summary>
        public void Dispose()
        {
            if (!_isCommit) Commit();
            _dbConnection?.Close();
            _dbConnection?.Dispose();
            _dbTransaction?.Dispose();
        }
    }
}
