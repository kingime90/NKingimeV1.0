using NKingime.Core.Data;

namespace NKingime.Core.EF
{
    /// <summary>
    /// 默认数据实体映射配置基类。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class DefaultEntityMapping<TEntity> : EntityMappingBase<TEntity, DefaultDbContext> where TEntity : class, IEntity
    {

    }
}
