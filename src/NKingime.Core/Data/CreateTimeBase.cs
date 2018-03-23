using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 创建时间数据实体基类。
    /// </summary>
    public abstract class CreateTimeBase : ICreateTime
    {
        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
