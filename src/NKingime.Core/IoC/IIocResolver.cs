using System;
using System.Collections.Generic;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 定义依赖注入对象解析器。
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 获取指定类型的实例。
        /// </summary>
        /// <typeparam name="T">要获取的类型。</typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// 获取指定类型的实例。
        /// </summary>
        /// <param name="type">要获取的类型。</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 获取指定类型的所有实例序列。
        /// </summary>
        /// <typeparam name="T">要获取的类型。</typeparam>
        /// <returns></returns>
        IEnumerable<T> Resolves<T>();

        /// <summary>
        /// 获取指定类型的所有实例序列。
        /// </summary>
        /// <param name="type">要获取的类型。</param>
        /// <returns></returns>
        IEnumerable<object> Resolves(Type type);
    }
}
