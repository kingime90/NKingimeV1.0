
namespace NKingime.Core.Data
{
    /// <summary>
    /// 唯一标识数据实体接口。
    /// </summary>
    /// <typeparam name="T">主键类型。</typeparam>
    public interface IIdentify<T> : IEntity
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        T Id { get; set; }
    }
}
