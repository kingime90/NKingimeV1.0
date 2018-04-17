using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using NKingime.Core.Generic;
using NKingime.Core.Extension;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 排序选择器。
    /// </summary>
    /// <typeparam name="TEntity">泛型实体。</typeparam>
    public class OrderSelector<TEntity> where TEntity : class
    {
        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity}"/>新实例。
        /// </summary>
        /// <param name="keySelector">用于从元素中提取键的函数列表。</param>
        public OrderSelector(IList<Expression<Func<TEntity, dynamic>>> keySelectors)
        {
            _keySelectors = new ReadOnlyList<Expression<Func<TEntity, dynamic>>>(keySelectors);
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity}"/>新实例。
        /// </summary>
        /// <param name="keySelector">用于从元素中提取键的函数列表。</param>
        public OrderSelector(ListSortDirection sortDirection, IList<Expression<Func<TEntity, dynamic>>> keySelectors) : this(keySelectors)
        {
            _sortDirection = sortDirection;
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity}"/>新实例。
        /// </summary>
        /// <param name="keySelectors"></param>
        public OrderSelector(params Expression<Func<TEntity, dynamic>>[] keySelectors)
        {
            if (keySelectors.IsNotNull())
            {
                _keySelectors = new ReadOnlyList<Expression<Func<TEntity, dynamic>>>(keySelectors);
            }
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity}"/>新实例。
        /// </summary>
        /// <param name="sortDirection"></param>
        /// <param name="keySelectors"></param>
        public OrderSelector(ListSortDirection sortDirection, params Expression<Func<TEntity, dynamic>>[] keySelectors) : this(keySelectors)
        {
            _sortDirection = sortDirection;
        }

        private readonly ReadOnlyList<Expression<Func<TEntity, dynamic>>> _keySelectors;

        /// <summary>
        /// 用于从元素中提取键的函数列表。
        /// </summary>
        public IReadOnlyList<Expression<Func<TEntity, dynamic>>> KeySelectors
        {
            get
            {
                return _keySelectors;
            }
        }

        private readonly ListSortDirection _sortDirection = ListSortDirection.Ascending;

        /// <summary>
        /// 排序方向。
        /// </summary>
        public ListSortDirection SortDirection
        {
            get
            {
                return _sortDirection;
            }
        }
    }
}
