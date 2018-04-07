using System;
using NKingime.Core.Extension;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据上下文配置。
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
            NameOrConnectionString = element.NameOrConnectionString;
            Enabled = element.EnabledValue.CastTo<bool?>().GetOrDefault(false).Value;
            DbContextInitializer = new DbContextInitializerConfig(element.DbContextInitializer);
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
        /// 数据库连接名称或字符串。
        /// </summary>
        public string NameOrConnectionString { get; private set; }

        /// <summary>
        /// 是否启用。
        /// </summary>
        public bool Enabled { get; private set; }

        /// <summary>
        /// 数据库上下文初始化。
        /// </summary>
        public DbContextInitializerConfig DbContextInitializer { get; private set; }
    }
}
