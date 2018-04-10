using System;
using NKingime.Core.Config;

namespace NKingime.Core.Initializer
{
    /// <summary>
    /// 上下文初始化接口。
    /// </summary>
    public interface IContextInitializer
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="config">上下文配置。</param>
        void Initialize(ContextConfig config);
    }
}
