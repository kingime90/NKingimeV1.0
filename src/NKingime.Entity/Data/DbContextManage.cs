using System;
using System.Collections.Generic;
using System.Linq;
using NKingime.Entity.Initializer;

namespace NKingime.Entity.Data
{
    /// <summary>
    /// 数据库上下文管理。
    /// </summary>
    public sealed class DbContextManage
    {
        /// <summary>
        /// 线程安全延迟加载实例。
        /// </summary>
        private static readonly Lazy<DbContextManage> LazyInstance = new Lazy<DbContextManage>(() => new DbContextManage());

        /// <summary>
        /// 数据库上下文初始化缓存。
        /// </summary>
        private readonly IDictionary<Type, DbContextInitializerBase> _dbContextInitializerCache = new Dictionary<Type, DbContextInitializerBase>();

        /// <summary>
        /// 实体数据库上下文类型缓存。
        /// </summary>
        private readonly IDictionary<Type, Type> _entityDbContextTypeCache = new Dictionary<Type, Type>();

        /// <summary>
        /// 初始化一个<see cref="DbContextManage"/>类型的新实例。
        /// </summary>
        private DbContextManage()
        {

        }

        /// <summary>
        /// 实例。
        /// </summary>
        public static DbContextManage Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        /// <summary>
        /// 注册数据库上下文初始化。
        /// </summary>
        /// <param name="contextType">数据库上下文类型。</param>
        /// <param name="initializer">数据库上下文初始化。</param>
        public void RegisterInitializer(Type contextType, DbContextInitializerBase initializer)
        {
            if (_dbContextInitializerCache.ContainsKey(contextType))
            {
                return;
            }
            _dbContextInitializerCache.Add(contextType, initializer);
            initializer.Initializer();
        }

        /// <summary>
        /// 根据指定实体类型获取数据库上下文类型。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <returns></returns>
        public Type GetDbContextType(Type entityType)
        {
            Type dbContextType;
            if (_entityDbContextTypeCache.ContainsKey(entityType))
            {
                dbContextType = _entityDbContextTypeCache[entityType];
            }
            else
            {
                var dbContextInitializer = _dbContextInitializerCache.FirstOrDefault(p => p.Value.EntityMappers.ContainsKey(entityType));
                //没有匹配项
                if (default(KeyValuePair<Type, DbContextInitializerBase>).Equals(dbContextInitializer))
                {

                }
                dbContextType = dbContextInitializer.Key;
                _entityDbContextTypeCache.Add(entityType, dbContextType);
            }
            return dbContextType;
        }

        /// <summary>
        /// 根据数据库上下文类型获取数据实体映射实例集合。
        /// </summary>
        /// <param name="dbContextType"></param>
        /// <returns></returns>
        public IEnumerable<IEntityMapper> GetEntityMappers(Type dbContextType)
        {
            DbContextInitializerBase initializer;
            if (_dbContextInitializerCache.TryGetValue(dbContextType, out initializer))
            {
                return initializer.EntityMappers.Values;
            }
            return Enumerable.Empty<IEntityMapper>();
        }
    }
}
