using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Core.Generic;

namespace NKingime.Core.Utility
{
    /// <summary>
    /// 排序应用。
    /// </summary>
    public static class OrderUtil
    {
        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Ascending<TEntity>(IList<Expression<Func<TEntity, dynamic>>> keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(keySelectors);
        }

        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Ascending<TEntity>(params Expression<Func<TEntity, dynamic>>[] keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(keySelectors);
        }

        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Descending<TEntity>(IList<Expression<Func<TEntity, dynamic>>> keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(ListSortDirection.Descending, keySelectors);
        }

        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Descending<TEntity>(params Expression<Func<TEntity, dynamic>>[] keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(ListSortDirection.Descending, keySelectors);
        }
    }
}
