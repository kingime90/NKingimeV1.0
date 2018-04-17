using System;
using System.Collections.Generic;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 分页结果。
    /// </summary>
    /// <typeparam name="T">分页实体类型。</typeparam>
    public class PagedResult<T> : PagedResultBase<T>
    {
        /// <summary>
        /// 初始化一个<see cref="PagedResult{T}"/>类型的新实例。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="totalCount">总记录数。</param>
        /// <param name="resultList">分页结果列表。</param>
        public PagedResult(int pageSize, int pageIndex, int totalCount, IEnumerable<T> resultList) : base(pageSize, pageIndex, totalCount, resultList)
        {

        }
    }
}
