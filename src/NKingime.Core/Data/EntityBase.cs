using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据实体基类。
    /// </summary>
    public abstract class EntityBase<TKey> : IdentifyBase<TKey>, ICreateTime
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNew">是否新增。</param>
        public EntityBase(bool isNew = true) : base(isNew)
        {
            if (!isNew)
                return;
            //
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
