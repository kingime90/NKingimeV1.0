using System;
using NKingime.Core.Config;
using NKingime.Core.Dependency;

namespace NKingime.Core.Initializer
{
    /// <summary>
    /// 定义数据库初始化接口。
    /// </summary>
    public interface IDatabaseInitializer : ISingletonDependency
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="contextConfigs">数据库上下文配置。</param>
        void Initialize(params DbContextConfig[] contextConfigs);
    }
}
