
namespace NKingime.Core.Flag
{
    /// <summary>
    /// 生命周期标识。
    /// </summary>
    public enum LifetimeScopeFlag
    {
        /// <summary>
        /// 实时模式，每次创建一个不同的对象。
        /// </summary>
        Transient,

        /// <summary>
        /// 局部模式，同一生命周期获得相同对象，不同生命周期获得不同对象。
        /// </summary>
        Scoped,

        /// <summary>
        /// 单例模式，在第一次获取实例时创建，之后都获得相同对象。
        /// </summary>
        Singleton,
    }
}
