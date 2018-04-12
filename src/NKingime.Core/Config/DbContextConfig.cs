using System;
using NKingime.Core.Extension;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据库上下文配置。
    /// </summary>
    public class DbContextConfig
    {
        /// <summary>
        /// 初始化一个<see cref="DbContextConfig"/>类型的新实例。
        /// </summary>
        /// <param name="element"></param>
        public DbContextConfig(DbContextElement element)
        {
            Name = element.Name;
            ContextType = Type.GetType(element.ContextTypeName);
            if (ContextType == null)
            {
                //异常处理
            }
            ConnectionStringName = element.ConnectionStringName;
            Enabled = element.EnabledValue.CastTo<bool?>().GetOrDefault(false).Value;
            InitializerConfig = new DbContextInitializerConfig(element.DbContextInitializer);
        }

        /// <summary>
        /// 节点名称。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 数据库上下文类型。
        /// </summary>
        public Type ContextType { get; private set; }

        /// <summary>
        /// 数据库连接字符串名称。
        /// </summary>
        public string ConnectionStringName { get; private set; }

        /// <summary>
        /// 是否启用。
        /// </summary>
        public bool Enabled { get; private set; }

        /// <summary>
        /// 数据库上下文初始化配置。
        /// </summary>
        public DbContextInitializerConfig InitializerConfig { get; private set; }
    }
}
