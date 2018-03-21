using NKingime.Core.Data;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace NKingime.Core.EF
{
    /// <summary>
    /// 数据实体映射配置基类。
    /// </summary>
    public abstract class EntityConfigurationBase<TEntity> : EntityTypeConfiguration<TEntity>, IEntityMapper where TEntity : class, IEntity
    {
        /// <summary>
        /// 将数据实体映射对象注册到当前数据访问上下文实体映射配置注册器中。
        /// </summary>
        /// <param name="configurations">实体映射配置注册器。</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
