using System;
using System.Data;
using System.Data.Entity;
using NKingime.Core.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data.Entity.Core.Objects;

namespace NKingime.Core.EF
{
    /// <summary>
    /// 数据库上下文基类。
    /// </summary>
    public abstract class DbContextBase<TDbContext> : DbContext, IUnitOfWork where TDbContext : DbContext, IUnitOfWork, new()
    {
        #region 构造函数

        protected DbContextBase() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected DbContextBase(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        protected DbContextBase(DbCompiledModel model) : base(model)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="model"></param>
        protected DbContextBase(string nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="contextOwnsConnection"></param>
        protected DbContextBase(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectContext"></param>
        /// <param name="dbContextOwnsObjectContext"></param>
        public DbContextBase(ObjectContext objectContext, bool dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="model"></param>
        /// <param name="contextOwnsConnection"></param>
        public DbContextBase(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
        {

        }

        #endregion

        #region 属性

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

        }

        #endregion
    }
}
