using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 创建时间数据实体接口。
    /// </summary>
    public interface ICreateTime : IEntity
    {
        /// <summary>
        /// 创建时间。
        /// </summary>
        DateTime CreateTime { get; set; }
    }
}
