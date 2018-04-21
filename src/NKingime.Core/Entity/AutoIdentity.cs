using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NKingime.Core.Extension;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 自增唯一标识数据实体基类。
    /// </summary>
    public abstract class AutoIdentity : IEntity<int>
    {
        /// <summary>
        /// 主键ID（自增）。
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region 重载

        /// <summary>
        /// 确定指定的 System.Object 是否等于当前的 System.Object。
        /// </summary>
        /// <param name="obj">与当前的 System.Object 进行比较的 System.Object。</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this.IsNull() || obj.IsNull())
            {
                return false;
            }
            var autoIdentity = obj as AutoIdentity;
            if (autoIdentity.IsNull())
            {
                return false;
            }
            return autoIdentity.Id > 0 && Id == autoIdentity.Id;
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
