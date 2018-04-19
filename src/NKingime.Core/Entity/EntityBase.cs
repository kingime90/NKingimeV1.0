using System;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 唯一标识数据实体基类，继承基类 <see cref="AutoIdentity"/>，实现接口 <see cref="ICreateTime"/>。
    /// </summary>
    public abstract class EntityBase : AutoIdentity, ICreateTime
    {
        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
