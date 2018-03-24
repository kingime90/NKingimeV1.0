using System;
using System.ComponentModel.DataAnnotations;

namespace NKingime.Core.Data
{
    /// <summary>
    /// Guid唯一标识数据实体基类。
    /// </summary>
    public abstract class GuidEntity : IIdentify<string>, IGuidIdentify
    {
        /// <summary>
        /// 主键ID（Guid）。
        /// </summary>
        [Key]
        public string Id { get; set; }
    }
}
