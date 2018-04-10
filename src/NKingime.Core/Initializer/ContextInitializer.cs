using System;
using NKingime.Core.Config;
using System.Linq;

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
        private static bool IsDatabaseInitializer;

        /// <summary>
        /// 
        /// </summary>
        public ContextInitializer()
        {
            DatabaseInitializer = new DatabaseInitializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseInitializer"></param>
        public ContextInitializer(IDatabaseInitializer databaseInitializer)
        {
            DatabaseInitializer = databaseInitializer;
        }

        /// <summary>
        /// 数据库初始化。
        /// </summary>
        public IDatabaseInitializer DatabaseInitializer { get; private set; }

        /// <summary>
        /// 初始化上下文。
        /// </summary>
        /// <param name="config">上下文配置。</param>
        public void Initialize(ContextConfig config)
        {
            if (!IsDatabaseInitializer)
            {
                DatabaseInitializer.Initialize(config.DbContexts.ToArray());
                IsDatabaseInitializer = true;
            }
        }
    }
}
