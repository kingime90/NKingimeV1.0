using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.ComponentModel;
using EntityFramework.Extensions;
using NKingime.Core.Data;
using NKingime.Core.Utility;
using NKingime.Core.Extension;
using NKingime.Core.Generic;
using NKingime.Entity.Extension;
using NKingime.Core.Entity;

namespace NKingime.Entity.Data
{
    /// <summary>
    /// EntityFramework数据仓储。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    public class EFRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity
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
        /// 无跟踪查询，查询出来的对象将不能用于修改。
        /// </summary>
        public override IQueryable<TEntity> Entities
        {
            get { return _dbSet.AsNoTracking(); }
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
        /// 保存数据实体集合。
        /// </summary>
        /// <param name="entities">数据实体集合。</param>
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
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int DeleteByKey<TKey>(TKey key)
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
        /// 删除数据实体集合。
        /// </summary>
        /// <param name="entities">数据实体集合。</param>
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
            ((DbContext)UnitOfWork).Update(entity);
            return UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 更新数据实体数组。
        /// </summary>
        /// <param name="entities">数据实体数组。</param>
        /// <returns>返回受影响的行数。</returns>
        public override int Update(IEnumerable<TEntity> entities)
        {
            ((DbContext)UnitOfWork).Update(entities.ToArray());
            return UnitOfWork.SaveChanges();
        }

        #endregion

        #region 查询

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        public override TEntity GetByKey<TKey>(TKey key)
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
        /// 根据指定筛选表达式获取数据实体列表。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器集合。</param>
        /// <returns></returns>
        public override List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
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
            //
            return queryable.ToList();
        }

        #endregion

        #region 分页

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器集合。</param>
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
        /// <param name="orderSelectors">排序选择器集合。</param>
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

        #endregion
    }
}
