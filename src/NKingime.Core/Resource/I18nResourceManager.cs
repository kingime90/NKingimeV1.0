using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using NKingime.Core.Extension;

namespace NKingime.Core.Resource
{
    /// <summary>
    /// 全球化资源管理。
    /// </summary>
    public sealed class I18nResourceManager
    {
        /// <summary>
        /// 线程安全延迟加载实例。
        /// </summary>
        private static readonly Lazy<I18nResourceManager> LazyInstance = new Lazy<I18nResourceManager>(() => new I18nResourceManager());

        /// <summary>
        /// 全球化资源管理缓存。
        /// </summary>
        private readonly IDictionary<string, ResourceManager> _resourceManagerCache = new Dictionary<string, ResourceManager>();

        /// <summary>
        /// 初始化一个<see cref="ContextResourceManager"/>类型的新实例。
        /// </summary>
        private I18nResourceManager()
        {

        }

        /// <summary>
        /// 实例。
        /// </summary>
        public static I18nResourceManager Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        /// <summary>
        /// 获取缓存键。
        /// </summary>
        /// <param name="baseName">资源的根名称。</param>
        /// <param name="cultureName">区域性名称。</param>
        /// <param name="assembly">资源的主 System.Reflection.Assembly。</param>
        /// <returns></returns>
        public static string GetCacheKey(string baseName, string cultureName, Assembly assembly)
        {
            baseName.CheckNotNull(() => nameof(baseName));
            cultureName.CheckNotNull(() => nameof(cultureName));
            assembly.CheckNotNull(() => nameof(assembly));
            return $"{assembly.GetName().Name}.I18n.{baseName}.{cultureName.ToUpper()}";
        }

        /// <summary>
        /// 返回指定的 System.String 资源的值。
        /// </summary>
        /// <param name="name">要获取的资源名。</param>
        /// <param name="cacheKey">缓存键。</param>
        /// <param name="assembly">资源的主 System.Reflection.Assembly。</param>
        /// <param name="culture">区域性信息。</param>
        /// <returns></returns>
        public string GetString(string name, string cacheKey, Assembly assembly)
        {
            name.CheckNotNull(() => nameof(name));
            var resourceManager = Get(cacheKey, assembly);
            return resourceManager.GetString(name);
        }

        /// <summary>
        /// 获取资源管理缓存。
        /// </summary>
        /// <param name="cacheKey">缓存键。</param>
        /// <param name="assembly">资源的主 System.Reflection.Assembly。</param>
        /// <returns></returns>
        public ResourceManager Get(string cacheKey, Assembly assembly)
        {
            cacheKey.CheckNotNull(() => nameof(cacheKey));
            assembly.CheckNotNull(() => nameof(assembly));
            ResourceManager resourceManager;
            if (_resourceManagerCache.TryGetValue(cacheKey, out resourceManager))
            {
                return resourceManager;
            }
            resourceManager = new ResourceManager(cacheKey, assembly);
            _resourceManagerCache.Add(cacheKey, resourceManager);
            return resourceManager;
        }
    }
}
