using System;
using System.Linq.Expressions;
using NKingime.Core.Flag;
using System.Collections.Generic;

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

        public OrderSelector(Expression<Func<TEntity, dynamic>> keySelector) : this()
        {
            _keySelectors.Add(keySelector);
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity,TKey}"/>新实例。
        /// </summary>
        /// <param name="keySelector">用于从元素中提取键的函数集合。</param>
        public OrderSelector(ICollection<Expression<Func<TEntity, dynamic>>> keySelectors)
        {
            _keySelectors = keySelectors;
        }

        private ICollection<Expression<Func<TEntity, dynamic>>> _keySelectors;

        /// <summary>
        /// 用于从元素中提取键的函数集合。
        /// </summary>
        public ICollection<Expression<Func<TEntity, dynamic>>> KeySelectors
        {
            get
            {
                return _keySelectors;
            }
        }

        private OrderByFlag _orderBy = OrderByFlag.Asc;

        /// <summary>
        /// 排序方式。
        /// </summary>
        public OrderByFlag OrderBy
        {
            get
            {
                return _orderBy;
            }
            set
            {
                _orderBy = value;
            }
        }
    }
}
