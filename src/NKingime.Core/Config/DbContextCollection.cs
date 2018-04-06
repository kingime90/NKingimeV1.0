using System;
using System.Configuration;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据库上下文配置元素集合。
    /// </summary>
    public class DbContextCollection : ConfigurationElementCollection
    {
        private const string DbContextKey = "dbContext";

        /// <summary>
        /// 获取 <see cref="T:System.Configuration.ConfigurationElementCollection"/> 的类型。
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        /// <summary>
        /// 获取在派生的类中重写时用于标识配置文件中此元素集合的名称。
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return DbContextKey;
            }
        }

        /// <summary>
        /// 当在派生的类中重写时，创建一个新的 <see cref="T:System.Configuration.ConfigurationElement"/>。
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new DbContextElement();
        }

        /// <summary>
        /// 在派生类中重写时获取指定配置元素的元素键。
        /// </summary>
        /// <param name="element">要为其返回键的 <see cref="T:System.Configuration.ConfigurationElement"/>。</param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DbContextElement)element).Name;
        }
    }
}
