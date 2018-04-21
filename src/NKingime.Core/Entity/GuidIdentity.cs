using System;
using System.ComponentModel.DataAnnotations;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// Guid唯一标识基类。
    /// </summary>
    public abstract class GuidIdentity : IEntity<string>
    {
        /// <summary>
        /// 主键ID（Guid）。
        /// </summary>
        [Key]
        public string Id { get; set; }
    }
}
