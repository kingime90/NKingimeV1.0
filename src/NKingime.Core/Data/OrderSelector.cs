using System;
using System.Linq.Expressions;
using NKingime.Core.Flag;

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

        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{TEntity,TKey}"/>新实例。
        /// </summary>
        /// <param name="keySelector">用于从元素中提取键的函数。</param>
        public OrderSelector(Expression<Func<TEntity, object>> keySelector)
        {
            KeySelector = keySelector;
        }

        /// <summary>
        /// 用于从元素中提取键的函数。
        /// </summary>
        public Expression<Func<TEntity, object>> KeySelector { get; set; }

        private OrderByFlag _orderBy = OrderByFlag.Asc;

        /// <summary>
        /// 排序方式
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
