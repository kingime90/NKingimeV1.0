using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NKingime.Core.Entity;
using NKingime.Core.Extension;

namespace NKingime.Entity.Extension
{
    /// <summary>
    /// 数据库上下文扩展方法。
    /// </summary>
    public static class DbContextExtension
    {
        /// <summary>
        /// 更新数据实体数组。
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型。</typeparam>
        /// <param name="dbContext">数据库上下文实例。</param>
        /// <param name="entities">数据实体数组。</param>
        public static void Update<TEntity>(this DbContext dbContext, params TEntity[] entities) where TEntity : class, IEntity
        {
            var dbSet = dbContext.Set<TEntity>();
            DbEntityEntry<TEntity> entry;
            var lastUpdateTime = DateTime.Now;
            foreach (TEntity entity in entities)
            {
                entry = dbContext.Entry(entity);
                //实体未由上下文跟踪
                if (entry.State == EntityState.Detached)
                {
                    //将给定实体附加到集的基础上下文中，将更新之前未由上下文跟踪的实体
                    dbSet.Attach(entity);
                    entry.State = EntityState.Modified;
                }
                if (entry.State == EntityState.Modified)
                {
                    //设置最后更新时间
                    entity.SetPropertyValue<TEntity, ILastUpdateTime, DateTime?>(s => s.LastUpdateTime, lastUpdateTime);
                }
            }
        }
    }
}
