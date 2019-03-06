using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructures.Repository
{
    /// <summary>
    /// 数据库连接项
    /// </summary>
    public class DbConnectionOptions
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbDialect DbType { get; set; }
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbDialect
    {
        SQLServer,
        PostgreSQL
    }
}
