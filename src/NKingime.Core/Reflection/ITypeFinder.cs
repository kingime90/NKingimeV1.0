using System;
using NKingime.Core.Generic;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 定义类型查找器接口。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITypeFinder<T> : IFinder<Type>
    {

    }
}
