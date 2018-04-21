using System;
using System.Linq;
using System.Reflection;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using NKingime.Core.Data;
using NKingime.Entity.Config;
using NKingime.Core.Extension;
using NKingime.Entity.Migrations;

namespace NKingime.Entity.Initializer
{
    /// <summary>
    /// 泛型数据库上下文初始化基类。
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class DbContextInitializerBase<TDbContext> : DbContextInitializerBase where TDbContext : DbContext, IUnitOfWork, new()
    {
        /// <summary>
        /// 初始化一个<see cref="DbContextInitializerBase{TDbContext}"/>新实例。
        /// </summary>
        public DbContextInitializerBase()
        {
            CreateDatabaseInitializer = new CreateDatabaseIfNotExists<TDbContext>();
            MigrateDatabaseInitializer = new MigrateDatabaseToLatestVersion<TDbContext, AutoMigrationsConfiguration<TDbContext>>();
        }

        private readonly Type _dbContextType = typeof(TDbContext);

        /// <summary>
        /// 获取数据库上下文类型。
        /// </summary>
        public Type DbContextType
        {
            get
            {
                return _dbContextType;
            }
        }

        /// <summary>
        /// 创建数据库初始化。
        /// </summary>
        public virtual IDatabaseInitializer<TDbContext> CreateDatabaseInitializer { get; protected set; }

        /// <summary>
        /// 数据库初始化实现，设置数据库初始化策略，并进行EntityFramework的预热。
        /// </summary>
        public virtual IDatabaseInitializer<TDbContext> MigrateDatabaseInitializer { get; protected set; }

        /// <summary>
        /// 数据库初始化，Entity Framework预热。
        /// </summary>
        protected override void ContextInitialize()
        {
            var dbContext = new TDbContext();
            IDatabaseInitializer<TDbContext> initializer;
            if (!dbContext.Database.Exists())
            {
                initializer = CreateDatabaseInitializer;
            }
            else
            {
                initializer = MigrateDatabaseInitializer;
            }
            Database.SetInitializer(initializer);
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            var mappingItemCollection = (StorageMappingItemCollection)objectContext.ObjectStateManager.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingItemCollection.GenerateViews(new List<EdmSchemaError>());
            dbContext.Dispose();
        }

        /// <summary>
        /// 数据实体映射过滤。
        /// </summary>
        /// <param name="entityMappers"></param>
        /// <returns></returns>
        protected override IEnumerable<IEntityMapper> EntityMappersFilter(IEnumerable<IEntityMapper> entityMappers)
        {
            return entityMappers.Where(p => p.DbContextType == DbContextType);
        }
    }

    /// <summary>
    /// 数据库上下文初始化基类。
    /// </summary>
    public abstract class DbContextInitializerBase
    {
        /// <summary>
        /// 映射程序集集合。
        /// </summary>
        public IEnumerable<Assembly> MapperAssemblys { get; set; }

        /// <summary>
        /// 当前上下文数据实体映射实例集合。
        /// </summary>
        public IReadOnlyDictionary<Type, IEntityMapper> EntityMappers { get; private set; }

        /// <summary>
        /// 初始化。
        /// </summary>
        public virtual void Initializer()
        {
            EntityMappersInitialize();
            ContextInitialize();
        }

        /// <summary>
        /// 数据库初始化，Entity Framework预热。
        /// </summary>
        protected abstract void ContextInitialize();

        /// <summary>
        /// 初始化实体映射类型。
        /// </summary>
        protected virtual void EntityMappersInitialize()
        {
            if (MapperAssemblys.IsNull())
            {

            }
            var baseType = typeof(IEntityMapper);
            var mapperTypes = MapperAssemblys.SelectMany(assembly => assembly.GetTypes()).Where(p => baseType.IsAssignableFrom(p) && !p.IsAbstract).Distinct().ToArray();
            IEnumerable<IEntityMapper> entityMappers = mapperTypes.Select(mapperType => Activator.CreateInstance(mapperType) as IEntityMapper);
            entityMappers = EntityMappersFilter(entityMappers).ToList();
            Type genericType, mapperBaseType, entityType;
            genericType = typeof(EntityMapperBase<,,>);
            var entityMapperSet = new Dictionary<Type, IEntityMapper>();
            foreach (var entityMapper in entityMappers)
            {
                if (!genericType.IsGenericAssignableFrom(entityMapper.GetType(), out mapperBaseType))
                {
                    continue;
                }
                entityType = mapperBaseType.GetGenericArguments().FirstOrDefault();
                if (entityMapperSet.ContainsKey(entityType))
                {
                    continue;
                }
                entityMapperSet.Add(entityType, entityMapper);
            }
            EntityMappers = new ReadOnlyDictionary<Type, IEntityMapper>(entityMapperSet);
        }

        /// <summary>
        /// 数据实体映射过滤。
        /// </summary>
        /// <param name="entityMappers">数据实体映射集合。</param>
        /// <returns></returns>
        protected abstract IEnumerable<IEntityMapper> EntityMappersFilter(IEnumerable<IEntityMapper> entityMappers);
    }
}
