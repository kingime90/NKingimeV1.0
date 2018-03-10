using System;
using System.Data;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 业务单元操作接口。
    /// </summary>
    public interface IUnitOfWork
    {
        #region 属性

        /// <summary>
        /// 是否开启事务提交。
        /// </summary>
        bool TransactionEnabled { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 显式开启数据库事物。
        /// </summary>
        /// <param name="isolationLevel">指定连接的事务锁定行为，默认<see cref="IsolationLevel.Unspecified"/>。</param>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);

        /// <summary>
        /// 提交数据库事物更改。
        /// </summary>
        void Commit();

        /// <summary>
        /// 显式回滚数据库事物。
        /// </summary>
        void Rollback();

        /// <summary>
        /// 提交当前单元操作的更改。
        /// </summary>
        /// <returns>操作影响的行数</returns>
        int SaveChanges();

        #endregion
    }
}
