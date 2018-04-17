using System;
using System.Collections.Generic;
using NKingime.Core.Generic;

namespace NKingime.Core.Utility
{
    /// <summary>
    ///  分页结果应用。
    /// </summary>
    public static class PagedResultUtil
    {
        /// <summary>
        /// 构建分页结果。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="totalRecord">总记录。</param>
        /// <param name="pageList">分页实体列表。</param>
        /// <returns></returns>
        public static PagedResult<T> BuildResult<T>(int pageSize, int pageIndex, int totalRecord, IEnumerable<T> pageList = null)
        {
            return new PagedResult<T>(pageSize, pageIndex, totalRecord, pageList);
        }

        /// <summary>
        /// 构建分页结果空列表。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <returns></returns>
        public static PagedResult<T> BuildEmptyResult<T>(int pageSize, int pageIndex)
        {
            return BuildResult<T>(pageSize, pageIndex, 0);
        }
    }
}
