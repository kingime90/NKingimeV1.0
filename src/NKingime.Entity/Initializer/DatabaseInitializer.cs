using System;
using NKingime.Entity.Data;
using NKingime.Core.Config;
using NKingime.Core.Extension;
using NKingime.Core.Initializer;

namespace NKingime.Entity.Initializer
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

        /// <summary>
        /// 数据库上下文初始化。
        /// </summary>
        /// <param name="contextConfig"></param>
        private void DbContextInit(DbContextConfig contextConfig)
        {
            if (!contextConfig.Enabled)
            {
                return;
            }
            //
            var dbContextInitializer = CreateDbContextInitializer(contextConfig.InitializerConfig);
            DbContextManage.Instance.RegisterInitializer(contextConfig.ContextType, dbContextInitializer);
        }

        /// <summary>
        /// 创建数据库上下文初始化。
        /// </summary>
        /// <param name="initializerConfig">数据库上下文初始化配置。</param>
        /// <returns></returns>
        private DbContextInitializerBase CreateDbContextInitializer(DbContextInitializerConfig initializerConfig)
        {
            var dbContextInitializer = Activator.CreateInstance(initializerConfig.InitializerType) as DbContextInitializerBase;
            if (dbContextInitializer.IsNull())
            {

            }
            dbContextInitializer.MapperAssemblys = initializerConfig.MapperAssemblys;
            return dbContextInitializer;
        }
    }
}
