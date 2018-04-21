using System;
using NKingime.Core.Entity;
using NKingime.Entity.Data;

namespace NKingime.Entity.Config
{
    /// <summary>
    /// 默认数据实体映射配置基类。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class DefaultEntityMapper<TEntity, TKey> : EntityMapperBase<TEntity, TKey, DefaultDbContext> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {

    }
}
