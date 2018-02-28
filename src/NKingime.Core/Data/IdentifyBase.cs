using System;
using NKingime.Core.Utility;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 唯一标识数据实体基类。
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class IdentifyBase<TKey> : IIdentify<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNew">是否新增。</param>
        public IdentifyBase(bool isNew = true)
        {
            if (!isNew)
                return;
            //
            var type = typeof(TKey).FullName;
            switch (type)
            {
                case "System.String":
                    Id = TypeConvertUtil.CastTo<TKey>(Guid.NewGuid().ToString());
                    break;
            }
        }

        /// <summary>
        /// 主键ID。
        /// </summary>
        public TKey Id { get; set; }
    }
}
