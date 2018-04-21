using System;
using System.Linq;
using System.Collections.Generic;
using NKingime.Core.Extension;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 分页结果基类。
    /// </summary>
    /// <typeparam name="T">分页实体类型。</typeparam>
    public abstract class PagedResultBase<T> : IPagedResult<T>
    {
        /// <summary>
        /// 默认每页多少条（默认10）。
        /// </summary>
        public static readonly int DefaultPageSize = 10;

        /// <summary>
        /// 起始页页码（默认1）。
        /// </summary>
        public static readonly int StartPageIndex = 1;

        /// <summary>
        /// 初始化一个<see cref="PagedResultBase{T}"/>类型的新实例。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="totalCount">总记录数。</param>
        /// <param name="resultList">分页结果列表。</param>
        public PagedResultBase(int pageSize, int pageIndex, int totalCount, IEnumerable<T> resultList)
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
            if (totalCount < 0)
            {
                totalCount = 0;
            }
            int totalPage = 0;
            if (totalCount > 0)
            {
                totalPage = totalCount % pageSize == 0 ? totalCount / pageSize : totalCount / pageSize + 1;
                if (pageIndex > totalPage)
                {
                    pageIndex = totalPage;
                }
            }
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            TotalPage = totalPage;
            SetResultList(resultList);
        }

        /// <summary>
        /// 每页多少条。
        /// </summary>
        public virtual int PageSize { get; }

        /// <summary>
        /// 页码。
        /// </summary>
        public virtual int PageIndex { get; }

        /// <summary>
        /// 总记录数。
        /// </summary>
        public virtual int TotalCount { get; }

        /// <summary>
        /// 总页码。
        /// </summary>
        public virtual int TotalPage { get; }

        /// <summary>
        /// 分页结果列表。
        /// </summary>
        public virtual IEnumerable<T> ResultList { get; private set; }

        /// <summary>
        /// 是否起始页。
        /// </summary>
        public virtual bool IsStart
        {
            get
            {
                return PageIndex == StartPageIndex;
            }
        }

        /// <summary>
        /// 是否尾页。
        /// </summary>
        public virtual bool IsEnd
        {
            get
            {
                return PageIndex == TotalPage;
            }
        }

        /// <summary>
        /// 是否空列表。
        /// </summary>
        public virtual bool IsEmpty
        {
            get
            {
                return TotalCount == 0;
            }
        }

        /// <summary>
        /// 是否有上一页。
        /// </summary>
        public virtual bool HasPrevious
        {
            get
            {
                return !IsEmpty && PageIndex > StartPageIndex;
            }
        }

        /// <summary>
        /// 是否有下一页。
        /// </summary>
        public virtual bool HasNext
        {
            get
            {
                return !IsEmpty && PageIndex < TotalPage;
            }
        }

        /// <summary>
        /// 设置分页结果列表。
        /// </summary>
        /// <param name="resultList">分页结果列表。</param>
        public virtual void SetResultList(IEnumerable<T> resultList)
        {
            ResultList = resultList.GetOrDefault(Enumerable.Empty<T>());
        }
    }
}
