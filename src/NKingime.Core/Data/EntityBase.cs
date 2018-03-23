using System;
using System.ComponentModel.DataAnnotations;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据实体基类。
    /// </summary>
    public abstract class EntityBase : CreateTimeBase, IIdentify<string>, IGuidIdentify
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        [Key]
        public string Id { get; set; }
    }
}
