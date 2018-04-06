using System;
using System.Configuration;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 上下文配置节。
    /// </summary>
    public class ContextSection : ConfigurationSection
    {
        private const string DbContextsKey = "dbContexts";

        /// <summary>
        /// 数据库上下文集合。
        /// </summary>
        [ConfigurationProperty(DbContextsKey)]
        public DbContextCollection DbContexts
        {
            get { return (DbContextCollection)this[DbContextsKey]; }
        }
    }
}
