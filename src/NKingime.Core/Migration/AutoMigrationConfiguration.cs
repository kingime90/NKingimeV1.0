using System.Data.Entity;
using System.Data.Entity.Migrations;
using NKingime.Core.Data;

namespace NKingime.Core.Migrations
{
    /// <summary>
    /// 自动与对给定模型使用迁移相关的配置。
    /// </summary>
    /// <typeparam name="TDbContext">数据库上下文。</typeparam>
    public class AutoMigrationConfiguration<TDbContext> : DbMigrationsConfiguration<TDbContext>
       where TDbContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// 初始化一个<see cref="AutoMigrationsConfiguration{TContext}"/>类型的新实例。
        /// </summary>
        public AutoMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = typeof(TDbContext).FullName;
        }
    }
}
