using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储泛型接口。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {

    }

    /// <summary>
    /// 数据仓储接口。
    /// </summary>
    public interface IRepository
    {

    }
}
