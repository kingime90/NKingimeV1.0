using System;
using NKingime.Core.Config;

namespace NKingime.Core.Initializer
{
    /// <summary>
    /// 数据库初始化。
    /// </summary>
    public class DatabaseInitializer : IDatabaseInitializer
    {
        /// <summary>
        /// 初始化数据库。
        /// </summary>
        /// <param name="contextConfigs"></param>
        public void Initialize(params DbContextConfig[] contextConfigs)
        {
            foreach (var contextConfig in contextConfigs)
            {
                DbContextInit(contextConfig);
            }
        }

        private static void DbContextInit(DbContextConfig contextConfig)
        {
            if (!contextConfig.Enabled)
            {
                return;
            }
            //

        }
    }
}
