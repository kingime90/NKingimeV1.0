using NKingime.Core.Extension;
using System;
using System.Configuration;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据库上下文配置元素。
    /// </summary>
    public class DbContextElement : ConfigurationElement
    {
        private const string NameKey = "name";

        private const string TypeKey = "type";

        private const string NameOrConnectionStringKey = "nameOrConnectionString";

        private const string EnabledKey = "enabled";

        private const string DbContextInitializerKey = "initializer";

        /// <summary>
        /// 节点名称。
        /// </summary>
        [ConfigurationProperty(NameKey)]
        public string Name
        {
            get { return Convert.ToString(this[NameKey]); }
            set { this[NameKey] = value; }
        }

        /// <summary>
        /// 数据库上下文类型名称。
        /// </summary>
        [ConfigurationProperty(TypeKey)]
        public string ContextTypeName
        {
            get { return Convert.ToString(this[TypeKey]); }
            set { this[TypeKey] = value; }
        }

        /// <summary>
        /// 数据库连接名称或字符串。
        /// </summary>
        [ConfigurationProperty(NameOrConnectionStringKey)]
        public string NameOrConnectionString
        {
            get { return Convert.ToString(this[NameOrConnectionStringKey]); }
            set { this[NameOrConnectionStringKey] = value; }
        }

        /// <summary>
        /// 是否启用值。
        /// </summary>
        [ConfigurationProperty(EnabledKey)]
        protected string EnabledValue
        {
            get { return Convert.ToString(this[EnabledKey]); }
            set { this[EnabledKey] = value; }
        }

        private bool? _enabled;

        /// <summary>
        /// 是否启用。
        /// </summary>
        public bool Enabled
        {
            get
            {
                if (!_enabled.HasValue)
                {
                    _enabled = EnabledValue.CastTo<bool?>().GetOrDefault(false).Value;
                }
                return _enabled.Value;
            }
        }

        /// <summary>
        /// 数据库上下文初始化配置。
        /// </summary>
        [ConfigurationProperty(DbContextInitializerKey)]
        public DbContextInitializerElement DbContextInitializer
        {
            get { return (DbContextInitializerElement)this[DbContextInitializerKey]; }
            set { this[DbContextInitializerKey] = value; }
        }
    }
}
