using System;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 唯一标识数据实体接口。
    /// </summary>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public interface IIdentify<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        TKey Id { get; set; }
    }
}
