using System;
using System.Collections;
using System.Collections.Generic;

namespace NKingime.Core.Generic
{
    /// <summary>
    /// 表示可按照索引单独访问的一组只读对象。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadOnlyList<T> : IReadOnlyList<T>
    {
        private readonly IList<T> source;

        /// <summary>
        /// 初始化一个<see cref="ReadOnlyList{T}"/>新实例。
        /// </summary>
        /// <param name="source"></param>
        public ReadOnlyList(IList<T> source)
        {
            this.source = source;
        }

        /// <summary>
        /// 获取指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得的元素从零开始的索引。</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return source[index];
            }
        }

        /// <summary>
        /// 获取集合中包含的元素数。
        /// </summary>
        public int Count
        {
            get
            {
                return source.Count;
            }
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return source.GetEnumerator();
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
