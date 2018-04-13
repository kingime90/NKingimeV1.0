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
        /// 页大小。
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 页码。
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 总记录。
        /// </summary>
        int TotalRecord { get; }

        /// <summary>
        /// 总页码。
        /// </summary>
        int TotalPage { get; }

        /// <summary>
        /// 分页实体列表。
        /// </summary>
        IEnumerable<T> PageList { get; }

        /// <summary>
        /// 是否起始页。
        /// </summary>
        bool IsStartPage { get; }

        /// <summary>
        /// 是否尾页。
        /// </summary>
        bool IsEndPage { get; }

        /// <summary>
        /// 是否空列表。
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// 是否有上一页。
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有下一页。
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// 设置分页实体列表。
        /// </summary>
        /// <param name="pageList">分页实体列表。</param>
        void SetPageList(IEnumerable<T> pageList);
    }
}
