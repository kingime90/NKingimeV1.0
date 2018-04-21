using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 上下文配置。
    /// </summary>
    public sealed class ContextConfig
    {
        /// <summary>
        /// 线程安全延迟加载实例。
        /// </summary>
        private static readonly Lazy<ContextConfig> LazyInstance = new Lazy<ContextConfig>(() => new ContextConfig());

        /// <summary>
        /// 上下文配置节名称。
        /// </summary>
        public const string ContextSectionName = "custom.config/context";

        /// <summary>
        /// 初始化一个<see cref="ContextConfig"/>类型的新实例。
        /// </summary>
        private ContextConfig()
        {

        }

        /// <summary>
        /// 实例。
        /// </summary>
        public static ContextConfig Instance
        {
            get
            {
                var contextConfig = LazyInstance.Value;
                if (contextConfig.DbContexts == null)
                {
                    contextConfig.DbContexts = GetDbContexts();
                }
                return contextConfig;
            }
        }

        /// <summary>
        /// 获取数据库上下文集合。
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<DbContextConfig> GetDbContexts()
        {
            var contextSection = (ContextSection)ConfigurationManager.GetSection(ContextSectionName);
            return contextSection.DbContexts.OfType<DbContextElement>().Select(s => new DbContextConfig(s)).ToList();
        }

        /// <summary>
        /// 数据库上下文集合。
        /// </summary>
        public IEnumerable<DbContextConfig> DbContexts { get; private set; }
    }
}
