using System;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 最后更新时间数据实体接口。
    /// </summary>
    public interface ILastUpdateTime
    {
        /// <summary>
        /// 最后更新时间（可空）。
        /// </summary>
        DateTime? LastUpdateTime { get; set; }
    }
}
