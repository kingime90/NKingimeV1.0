using System;
using System.Linq;
using NKingime.Core.Dependency;
using NKingime.Core.Extension;
using NKingime.Core.Config;

namespace NKingime.Core.Initializer
{
    /// <summary>
    /// 上下文初始化。
    /// </summary>
    public class ContextInitializer : IContextInitializer
    {
        /// <summary>
        /// 数据库是否已初始化。
        /// </summary>
        private static bool _databaseInitialized;

        /// <summary>
        /// 初始化上下文。
        /// </summary>
        /// <param name="iocBuilder">依赖注入构建器。</param>
        public void Initialize(IIocBuilder iocBuilder)
        {
            //依赖注入初始化
            IServiceProvider provider = iocBuilder.Build();

            ContextConfig contextConfig = ContextConfig.Instance;
            IDatabaseInitializer databaseInitializer = provider.GetService<IDatabaseInitializer>();
            if (!_databaseInitialized && databaseInitializer.IsNotNull())
            {
                databaseInitializer.Initialize(contextConfig.DbContexts.ToArray());
                _databaseInitialized = true;
            }
        }
    }
}
