using System;
using NKingime.Core.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace NKingime.Entity.Data
{
    /// <summary>
    /// 数据实体映射配置基类。
    /// </summary>
    public abstract class EntityMapperBase<TEntity, TDbContext> : EntityTypeConfiguration<TEntity>, IEntityMapper where TEntity : class, IEntity where TDbContext : DbContext, IUnitOfWork, new()
    {
        private readonly Type _dbContextType = typeof(TDbContext);

        /// <summary>
        /// 数据库上下文类型。
        /// </summary>
        public Type DbContextType
        {
            get
            {
                return _dbContextType;
            }
        }

        /// <summary>
        /// 将数据实体映射对象注册到当前数据访问上下文实体映射配置注册器中。
        /// </summary>
        /// <param name="configurations">实体映射配置注册器。</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            EntityMapping();
            configurations.Add(this);
        }

        /// <summary>
        /// 实体映射。
        /// </summary>
        protected virtual void EntityMapping()
        {

        }
    }
}
