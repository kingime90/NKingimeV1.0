using System;
using System.Collections.Generic;

namespace NKingime.Core.Public
{
    /// <summary>
    /// 分页结果。
    /// </summary>
    /// <typeparam name="T">分页实体类型。</typeparam>
    public class PagedResult<T> where T : class
    {
        /// <summary>
        /// 默认页大小（默认10）。
        /// </summary>
        public static readonly int DefaultPageSize = 10;

        /// <summary>
        /// 默认页码（默认1）。
        /// </summary>
        public static readonly int DefaultPageIndex = 1;

        /// <summary>
        /// 初始化一个<see cref="PagedResult{T}"/>类型的新实例。
        /// </summary>
        /// <param name="pageSize">页大小。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="totalRecord">总记录。</param>
        /// <param name="pageList">分页实体列表。</param>
        public PagedResult(int pageSize, int pageIndex, int totalRecord, IEnumerable<T> pageList)
        {
            if (pageSize <= 0)
            {
                pageSize = DefaultPageSize;
            }
            //
            if (pageIndex <= 0)
            {
                pageIndex = DefaultPageIndex;
            }
            //
            if (totalRecord < 0)
            {
                totalRecord = 0;
            }
            int totalPage = 0;
            if (totalRecord > 0)
            {
                totalPage = totalRecord % pageSize == 0 ? totalRecord / pageSize : totalRecord / pageSize + 1;
                if (pageIndex > totalPage)
                {
                    pageIndex = totalPage;
                }
            }
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalRecord = totalRecord;
            TotalPage = totalPage;
            PageList = pageList;
        }

        /// <summary>
        /// 页大小。
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// 页码。
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// 总记录。
        /// </summary>
        public int TotalRecord { get; }

        /// <summary>
        /// 总页码。
        /// </summary>
        public int TotalPage { get; }

        /// <summary>
        /// 分页实体列表。
        /// </summary>
        public IEnumerable<T> PageList { get; }
    }
}
