using NKingime.Core.Entity;
using NKingime.Entity.Data;

namespace NKingime.Entity.Config
{
    /// <summary>
    /// 默认数据实体映射配置基类。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class DefaultEntityMapper<TEntity> : EntityMapperBase<TEntity, DefaultDbContext> where TEntity : class, IEntity
    {

    }
}
