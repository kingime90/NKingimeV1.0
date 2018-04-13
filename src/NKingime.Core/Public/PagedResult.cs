using System;
using System.Collections.Generic;
using System.Linq;

namespace NKingime.Core.Public
{
    /// <summary>
    /// 分页结果。
    /// </summary>
    /// <typeparam name="T">分页实体类型。</typeparam>
    public class PagedResult<T> : IPagedResult<T>
    {
        /// <summary>
        /// 默认页大小（默认10）。
        /// </summary>
        public static readonly int DefaultPageSize = 10;

        /// <summary>
        /// 起始页页码（默认1）。
        /// </summary>
        public static readonly int StartPageIndex = 1;

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
                pageIndex = StartPageIndex;
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
            if (pageList == null)
            {
                pageList = Enumerable.Empty<T>();
            }
            PageList = pageList;
            //
            IsStartPage = PageIndex == StartPageIndex;
            IsEndPage = PageIndex == TotalPage;
            IsEmpty = TotalRecord == 0;
            HasPreviousPage = PageIndex > StartPageIndex;
            HasNextPage = PageIndex < TotalPage;
        }

        /// <summary>
        /// 初始化一个<see cref="PagedResult{T}"/>类型的新实例。
        /// </summary>
        /// <param name="pageSize">页大小。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="totalRecord">总记录。</param>
        public PagedResult(int pageSize, int pageIndex, int totalRecord) : this(pageSize, pageIndex, totalRecord, null)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="PagedResult{T}"/>类型的新实例。
        /// </summary>
        /// <param name="pageSize">页大小。</param>
        /// <param name="pageIndex">页码。</param>
        public PagedResult(int pageSize, int pageIndex) : this(pageSize, pageIndex, 0, null)
        {

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
        public IEnumerable<T> PageList { get; private set; }

        /// <summary>
        /// 是否起始页。
        /// </summary>
        public bool IsStartPage { get; }

        /// <summary>
        /// 是否尾页。
        /// </summary>
        public bool IsEndPage { get; }

        /// <summary>
        /// 是否空列表。
        /// </summary>
        public bool IsEmpty { get; }

        /// <summary>
        /// 是否有上一页。
        /// </summary>
        public bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有下一页。
        /// </summary>
        public bool HasNextPage { get; }

        /// <summary>
        /// 设置分页实体列表。
        /// </summary>
        /// <param name="pageList">分页实体列表。</param>
        public void SetPageList(IEnumerable<T> pageList)
        {
            if (pageList == null)
            {
                pageList = Enumerable.Empty<T>();
            }
            PageList = pageList;
        }
    }
}
