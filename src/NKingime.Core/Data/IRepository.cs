using System;
using NKingime.Core.IoC;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储泛型接口。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {
        /// <summary>
        /// 保存实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(TEntity entity);

        /// <summary>
        /// 保存实体集合。
        /// </summary>
        /// <param name="entity">数据实体集合。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(IEnumerable<TEntity> entities);

        /// <summary>
        /// 根据主键删除实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete<TKey>(TKey key) where TKey : IEquatable<TKey>;

        /// <summary>
        /// 删除实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(TEntity entity);

        /// <summary>
        /// 删除实体集合。
        /// </summary>
        /// <param name="entity">数据实体集合。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除所有符合条件的实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 更新实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Update(TEntity entity);

        /// <summary>
        /// 更新实体集合。
        /// </summary>
        /// <param name="entity">数据实体集合。</param>
        /// <returns>返回受影响的行数。</returns>
        int Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 根据主键获取实体。
        /// </summary>
        /// <typeparam name="TKey">主键。</typeparam>
        /// <param name="key"></param>
        /// <returns>如果检索到记录，返回数据实体，否则返回null。</returns>
        TEntity GetByKey<TKey>(TKey key) where TKey : IEquatable<TKey>;


    }

    /// <summary>
    /// 数据仓储接口。
    /// </summary>
    public interface IRepository: IScopedDependency
    {

    }
}
