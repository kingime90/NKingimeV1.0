using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Configuration;
using NKingime.Core.Config;
using NKingime.Core.Data;

namespace NKingime.Core.EF
{
    /// <summary>
    /// 数据库上下文基类。
    /// </summary>
    public abstract class DbContextBase<TDbContext> : DbContext, IUnitOfWork where TDbContext : DbContext, IUnitOfWork, new()
    {
        /// <summary>
        /// 数据库上下文配置。
        /// </summary>
        private static readonly DbContextConfig _dbContextConfig;

        #region 构造函数

        static DbContextBase()
        {
            _dbContextConfig = ContextConfig.Instance.DbContexts.FirstOrDefault(p => p.ContextType == DbContextType);
        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        protected DbContextBase() : base(GetConnectionStringName())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected DbContextBase(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        /// <param name="model"></param>
        protected DbContextBase(DbCompiledModel model) : base(model)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="model"></param>
        protected DbContextBase(string nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="contextOwnsConnection"></param>
        protected DbContextBase(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        /// <param name="objectContext"></param>
        /// <param name="dbContextOwnsObjectContext"></param>
        public DbContextBase(ObjectContext objectContext, bool dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>新实例。
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="model"></param>
        /// <param name="contextOwnsConnection"></param>
        public DbContextBase(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
        {

        }

        #endregion

        #region 属性

        private static readonly Type _dbContextType = typeof(TDbContext);

        /// <summary>
        /// 获取数据库上下文类型。
        /// </summary>
        public static Type DbContextType
        {
            get
            {
                return _dbContextType;
            }
        }

        /// <summary>
        /// 是否开启事务提交。
        /// </summary>
        public bool TransactionEnabled
        {
            get { return Database.CurrentTransaction != null; }
        }

        #endregion

        #region Implementation of IUnitOfWork

        /// <summary>
        /// 显式开启数据库事物。
        /// </summary>
        /// <param name="isolationLevel">指定连接的事务锁定行为，默认<see cref="IsolationLevel.Unspecified"/>。</param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (Database.CurrentTransaction == null)
            {
                Database.BeginTransaction(isolationLevel);
            }
        }

        /// <summary>
        /// 提交数据库事物更改。
        /// </summary>
        public void Commit()
        {
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 显式回滚数据库事物。
        /// </summary>
        public void Rollback()
        {
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }

        #endregion

        #region Override of DbContext

        /// <summary>
        /// 当已初始化派生上下文的模型时，但在模型被锁定并用于初始化Context之前，调用此方法。该方法的默认实现没有任何作用，但可以在派生类中重写该方法，以便在锁定模型之前进一步配置该模型。
        /// </summary>
        /// <param name="modelBuilder">为正在创建的上下文定义模型的生成器。</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            var entityMappers = DbContextManage.Instance.GetEntityMappers(DbContextType);
            foreach (IEntityMapper mapper in entityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 获取数据库连接字符串名称。
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionStringName()
        {
            var connectionStringName = _dbContextConfig.ConnectionStringName;
            if (ConfigurationManager.ConnectionStrings[connectionStringName] == null)
            {

            }
            return connectionStringName;
        }

        #endregion
    }
}
