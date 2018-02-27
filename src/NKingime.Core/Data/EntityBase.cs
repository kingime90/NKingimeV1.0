using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据实体基类。
    /// </summary>
    public abstract class EntityBase<TKey> : IIdentify<TKey>, ICreateTime
    {
        protected EntityBase()
        {

            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 主键ID。
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
