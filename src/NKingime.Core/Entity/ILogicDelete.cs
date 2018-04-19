using System;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 逻辑删除数据实体接口。
    /// </summary>
    public interface ILogicDelete
    {
        /// <summary>
        /// 是否已删除。
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
