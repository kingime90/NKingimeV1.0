using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Core.IoC;
using NKingime.Core.Generic;
using NKingime.Core.Entity;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储泛型接口。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public interface IRepository<TEntity, TKey> : IRepository where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        #region 属性

        /// <summary>
        /// 获取当前业务单元操作。
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 获取 当前数据实体类型的查询数据集，数据将使用不跟踪变化的方式来查询，当数据用于展现时，推荐使用此数据集，如果用于新增，更新，删除时，请使用<see cref="TrackEntities"/>数据集。
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// 获取 当前数据实体类型的查询数据集，当数据用于新增，更新，删除时，使用此数据集，如果数据用于展现，推荐使用<see cref="Entities"/>数据集。
        /// </summary>
        IQueryable<TEntity> TrackEntities { get; }

        #endregion

        #region 新增

        /// <summary>
        /// 保存数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(TEntity entity);

        /// <summary>
        /// 保存数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(IEnumerable<TEntity> entities);

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        int DeleteByKey(TKey key);

        /// <summary>
        /// 删除数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(TEntity entity);

        /// <summary>
        /// 删除数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region 更新

        /// <summary>
        /// 更新数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Update(TEntity entity);

        /// <summary>
        /// 更新数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        int Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="updateExpression">更新实体表达式。</param>
        /// <returns></returns>
        int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression);

        /// <summary>
        /// 根据主键逻辑删除数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        int RecycleByKey(TKey key);

        /// <summary>
        /// 逻辑删除数据实体。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Recycle(TEntity entity);

        /// <summary>
        /// 逻辑删除数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        int Recycle(IEnumerable<TEntity> entities);

        /// <summary>
        /// 逻辑删除所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        int Recycle(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据主键逻辑还原数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        int RestoreByKey(TKey key);

        /// <summary>
        /// 逻辑还原数据实体。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Restore(TEntity entity);

        /// <summary>
        /// 逻辑还原数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        int Restore(IEnumerable<TEntity> entities);

        /// <summary>
        /// 逻辑还原所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        int Restore(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region 查询

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate, TKey key = default(TKey));

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        TEntity GetByKey(TKey key);

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault();

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 查询所有数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> Query(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 查询所有数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> QueryTrack(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        #endregion

        #region 分页

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex);

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        #endregion

        #region 函数

        /// <summary>
        /// 返回实体集合中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }

    /// <summary>
    /// 数据仓储接口。
    /// </summary>
    public interface IRepository : IScopedDependency
    {

    }
}
