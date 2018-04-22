using System;
using NKingime.Core.IoC;
using NKingime.Core.Data;
using NKingime.Core.Entity;

namespace NKingime.Entity.IoC
{
    /// <summary>
    /// 定义数据库上下文解析器接口。
    /// </summary>
    public interface IDbContextTypeResolver : ISingletonDependency
    {
        /// <summary>
        /// 根据指定的数据实体类型获取关联的业务单元操作。
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型。</typeparam>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <returns></returns>
        IUnitOfWork Resolve<TEntity, TKey>() where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>;

        /// <summary>
        /// 根据指定的数据实体类型获取关联的业务单元操作。
        /// </summary>
        /// <param name="entityType">数据实体类型。</param>
        /// <returns></returns>
        IUnitOfWork Resolve(Type entityType);
    }
}
