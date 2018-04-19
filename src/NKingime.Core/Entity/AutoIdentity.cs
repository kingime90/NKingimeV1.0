using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 自增唯一标识数据实体基类。
    /// </summary>
    public abstract class AutoIdentity : IIdentify<int>
    {
        /// <summary>
        /// 主键ID（自增）。
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
