using System;

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
        public string Id { get; set; }
    }
}
