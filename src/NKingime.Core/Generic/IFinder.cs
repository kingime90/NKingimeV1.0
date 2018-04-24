using System;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 定义查找器接口。
    /// </summary>
    /// <typeparam name="T">要查找的项类型。</typeparam>
    public interface IFinder<out T>
    {
        /// <summary>
        /// 根据指定筛选表达式查找。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        T[] Find(Func<T, bool> predicate);

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        T[] FindAll();
    }
}
