using System;
using NKingime.Core.IoC;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NKingime.Core.Public;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储泛型接口。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        #region 属性

        /// <summary>
        /// 获取当前业务单元操作。
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        #endregion

        #region 新增

        /// <summary>
        /// 保存数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(TEntity entity);

        /// <summary>
        /// 保存数据实体数组。
        /// </summary>
        /// <param name="entities">数据实体数组。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(params TEntity[] entities);

        /// <summary>
        /// 保存数据实体集合。
        /// </summary>
        /// <param name="entities">数据实体集合。</param>
        /// <returns>返回受影响的行数。</returns>
        int Save(IEnumerable<TEntity> entities);

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除数据实体。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        int DeleteByKey<TKey>(TKey key) where TKey : IEquatable<TKey>;

        /// <summary>
        /// 删除数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(TEntity entity);

        /// <summary>
        /// 删除数据实体数组。
        /// </summary>
        /// <param name="entities">数据实体数组。</param>
        /// <returns>返回受影响的行数。</returns>
        int Delete(params TEntity[] entities);

        /// <summary>
        /// 删除数据实体集合。
        /// </summary>
        /// <param name="entities">数据实体集合。</param>
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
        /// 更新数据实体数组。
        /// </summary>
        /// <param name="entities">数据实体数组。</param>
        /// <returns>返回受影响的行数。</returns>
        int Update(params TEntity[] entities);

        /// <summary>
        /// 更新数据实体集合。
        /// </summary>
        /// <param name="entities">数据实体集合。</param>
        /// <returns>返回受影响的行数。</returns>
        int Update(IEnumerable<TEntity> entities);

        #endregion

        #region 查询

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        TEntity GetByKey<TKey>(TKey key) where TKey : IEquatable<TKey>;

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
        /// 查询所有数据实体列表。
        /// </summary>
        /// <returns></returns>
        List<TEntity> QueryAll();

        /// <summary>
        /// 查询所有数据实体列表。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> QueryAll(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器集合。</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

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
        /// <param name="orderSelectors">排序选择器集合。</param>
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
        /// <param name="orderSelectors">排序选择器集合。</param>
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
