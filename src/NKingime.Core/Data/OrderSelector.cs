using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.ComponentModel;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 排序选择器。
    /// </summary>
    /// <typeparam name="TEntity">泛型实体。</typeparam>
    public class OrderSelector<TEntity>
    {
        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity}"/>新实例。
        /// </summary>
        public OrderSelector()
        {
            _keySelectors = new List<Expression<Func<TEntity, dynamic>>>();
        }

        public OrderSelector(params Expression<Func<TEntity, dynamic>>[] keySelectors) : this()
        {
            if (keySelectors != null)
            {
                foreach (var keySelector in keySelectors)
                {
                    _keySelectors.Add(keySelector);
                }
            }
        }

        public OrderSelector(ListSortDirection sortDirection, params Expression<Func<TEntity, dynamic>>[] keySelectors) : this(keySelectors)
        {
            _sortDirection = sortDirection;
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity,TKey}"/>新实例。
        /// </summary>
        /// <param name="keySelector">用于从元素中提取键的函数列表。</param>
        public OrderSelector(IList<Expression<Func<TEntity, dynamic>>> keySelectors)
        {
            _keySelectors = keySelectors;
        }

        private IList<Expression<Func<TEntity, dynamic>>> _keySelectors;

        /// <summary>
        /// 用于从元素中提取键的函数列表。
        /// </summary>
        public IList<Expression<Func<TEntity, dynamic>>> KeySelectors
        {
            get
            {
                return _keySelectors;
            }
        }

        private ListSortDirection _sortDirection = ListSortDirection.Ascending;

        /// <summary>
        /// 排序方向。
        /// </summary>
        public ListSortDirection SortDirection
        {
            get
            {
                return _sortDirection;
            }
            set
            {
                _sortDirection = value;
            }
        }
    }
}
