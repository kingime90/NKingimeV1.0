using System;
using System.Collections.Generic;
using System.Linq;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 查找器基类。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FinderBase<T> : IFinder<T>
    {
        /// <summary>
        /// 根据指定筛选表达式查找。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return FindAll().Where(predicate);
        }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<T> FindAll();
    }
}
