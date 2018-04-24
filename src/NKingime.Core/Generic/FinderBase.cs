using System;
using System.Linq;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 查找器基类。
    /// </summary>
    /// <typeparam name="T">要查找的项类型。</typeparam>
    public abstract class FinderBase<T> : IFinder<T>
    {
        /// <summary>
        /// 根据指定筛选表达式查找。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public T[] Find(Func<T, bool> predicate)
        {
            return FindAll().Where(predicate).ToArray();
        }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public abstract T[] FindAll();
    }
}
