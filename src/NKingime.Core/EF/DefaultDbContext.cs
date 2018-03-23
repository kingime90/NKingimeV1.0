using System;

namespace NKingime.Core.EF
{
    /// <summary>
    /// 默认数据库上下文。
    /// </summary>
    public class DefaultDbContext : DbContextBase<DefaultDbContext>
    {
        /// <summary>
        /// 
        /// </summary>
        public DefaultDbContext() : base("Default")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public DefaultDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
