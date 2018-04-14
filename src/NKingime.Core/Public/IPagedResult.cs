using System;
using System.Collections.Generic;

namespace NKingime.Core.Public
{
    /// <summary>
    /// 分页结果接口。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedResult<T>
    {
        /// <summary>
        /// 每页多少条。
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 页码。
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 总记录数。
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// 总页码。
        /// </summary>
        int TotalPage { get; }

        /// <summary>
        /// 分页结果列表。
        /// </summary>
        IEnumerable<T> ResultList { get; }

        /// <summary>
        /// 是否起始页。
        /// </summary>
        bool IsStart { get; }

        /// <summary>
        /// 是否尾页。
        /// </summary>
        bool IsEnd { get; }

        /// <summary>
        /// 是否空列表。
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// 是否有上一页。
        /// </summary>
        bool HasPrevious { get; }

        /// <summary>
        /// 是否有下一页。
        /// </summary>
        bool HasNext { get; }

        /// <summary>
        /// 设置分页结果列表。
        /// </summary>
        /// <param name="resultList">分页结果列表。</param>
        void SetResultList(IEnumerable<T> resultList);
    }
}
