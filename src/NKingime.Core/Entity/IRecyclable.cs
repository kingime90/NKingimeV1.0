using System;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 定义逻辑删除接口。
    /// </summary>
    public interface IRecyclable
    {
        /// <summary>
        /// 是否已删除。
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
