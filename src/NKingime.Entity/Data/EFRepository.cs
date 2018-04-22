using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;
using EntityFramework.Extensions;
using NKingime.Core.Data;
using NKingime.Core.Entity;
using NKingime.Core.Generic;
using NKingime.Core.Utility;
using NKingime.Core.Extension;
using NKingime.Entity.Extension;

namespace NKingime.Entity.Data
{
    /// <summary>
    /// EntityFramework数据仓储。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public class EFRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 初始化一个<see cref="EFRepository{TEntity}"/>新实例。
        /// </summary>
        public EFRepository()
        {
            var dbContext = new DefaultDbContext();
            UnitOfWork = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        #region 属性

        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// 获取当前业务单元操作。
        /// </summary>
        public override IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 获取 当前数据实体类型的查询数据集，数据将使用不跟踪变化的方式来查询，当数据用于展现时，推荐使用此数据集，如果用于新增，更新，删除时，请使用<see cref="TrackEntities"/>数据集。
        /// </summary>
        public override IQueryable<TEntity> Entities
        {
            get { return _dbSet.AsNoTracking(); }
        }

        /// <summary>
        /// 获取 当前数据实体类型的查询数据集，当数据用于新增，更新，删除时，使用此数据集，如果数据用于展现，推荐使用<see cref="Entities"/>数据集。
        /// </summary>
        public override IQueryable<TEntity> TrackEntities
        {
            get { return _dbSet; }
        }

        #endregion

        #region 新增

        /// <summary>
        /// 保存数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Save(TEntity entity)
        {
            CheckCreateTime(entity, DateTime.Now);
            _dbSet.Add(entity);
            return UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 保存数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Save(IEnumerable<TEntity> entities)
        {
            var createTime = DateTime.Now;
            foreach (var entity in entities)
            {
                CheckCreateTime(entity, createTime);
            }
            _dbSet.AddRange(entities);
            return UnitOfWork.SaveChanges();
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int DeleteByKey(TKey key)
        {
            var entity = GetByKey(key);
            return entity.IsNull() ? 0 : Delete(entity);
        }

        /// <summary>
        /// 删除数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Delete(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 删除所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate).ToList();
            return entities.Count() == 0 ? 0 : Delete(entities);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Update(TEntity entity)
        {
            ((DbContext)UnitOfWork).Update<TEntity, TKey>(entity);
            return UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 更新数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Update(IEnumerable<TEntity> entities)
        {
            ((DbContext)UnitOfWork).Update<TEntity, TKey>(entities as TEntity[] ?? entities.ToArray());
            return UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 更新所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="updateExpression">更新实体表达式。</param>
        /// <returns></returns>
        public override int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            return _dbSet.Where(predicate).Update(updateExpression);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        public override bool Exists(Expression<Func<TEntity, bool>> predicate, TKey key = default(TKey))
        {
            if (!key.Equals(default(TKey)) && !string.IsNullOrWhiteSpace(key.CastTo<string>()))
            {
                predicate = predicate.And(p => !p.Id.Equals(key));
            }
            return _dbSet.Count(predicate) > 0;
        }

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        public override TEntity GetByKey(TKey key)
        {
            return _dbSet.Find(key);
        }

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            IQueryable<TEntity> queryable = _dbSet;
            if (predicate.IsNotNull())
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderSelectors.IsNotEmpty())
            {
                queryable = OrderBy(queryable, orderSelectors);
            }
            //
            return queryable.FirstOrDefault();
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public override List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            return Query(false, predicate, orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public override List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            return Query(true, predicate, orderSelectors);
        }

        #endregion

        #region 分页

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public override IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            var totalRecord = Count(predicate);
            var pagedResult = PagedResultUtil.BuildResult<TEntity>(pageSize, pageIndex, totalRecord);
            if (pagedResult.IsEmpty)
            {
                return pagedResult;
            }
            IQueryable<TEntity> queryable = Entities;
            if (predicate.IsNotNull())
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderSelectors.IsNotEmpty())
            {
                queryable = OrderBy(queryable, orderSelectors);
            }
            queryable = queryable.Skip(pagedResult.PageSize * (pagedResult.PageIndex - 1)).Take(pagedResult.PageSize);
            pagedResult.SetResultList(queryable.ToList());
            return pagedResult;
        }

        #endregion

        #region 函数

        /// <summary>
        /// 返回实体集合中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public override int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate.IsNotNull() ? _dbSet.Count(predicate) : _dbSet.Count();
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 根据指定排序选择器集合排序。
        /// </summary>
        /// <param name="queryable">提供对数据类型已知的特定数据源的查询进行计算的功能。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        protected IOrderedQueryable<TEntity> OrderBy(IQueryable<TEntity> queryable, params OrderSelector<TEntity>[] orderSelectors)
        {
            int index = 0;
            bool isAscending;
            IOrderedQueryable<TEntity> orderedQueryable = null;
            foreach (var orderSelector in orderSelectors)
            {
                isAscending = orderSelector.SortDirection == ListSortDirection.Ascending;
                foreach (var keySelector in orderSelector.KeySelectors)
                {
                    if (index == 0)
                    {
                        orderedQueryable = isAscending ? queryable.OrderBy(keySelector) : queryable.OrderByDescending(keySelector);
                    }
                    else
                    {
                        orderedQueryable = isAscending ? orderedQueryable.ThenBy(keySelector) : orderedQueryable.ThenByDescending(keySelector);
                    }
                    //
                    index++;
                }
            }
            return orderedQueryable;
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表。
        /// </summary>
        /// <param name="isTrack">是否跟踪查询。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        private List<TEntity> Query(bool isTrack, Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            IQueryable<TEntity> queryable = isTrack.IfElse(_dbSet, Entities);
            if (predicate.IsNotNull())
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderSelectors.IsNotEmpty())
            {
                queryable = OrderBy(queryable, orderSelectors);
            }
            //
            return queryable.ToList();
        }

        #endregion
    }
}
