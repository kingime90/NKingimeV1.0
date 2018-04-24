using System;
using NKingime.Core.Dependency;

namespace NKingime.Core.Initializer
{
    /// <summary>
    /// 定义上下文初始化接口。
    /// </summary>
    public interface IContextInitializer
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="iocBuilder">依赖注入构建器。</param>
        void Initialize(IIocBuilder iocBuilder);
    }
}
