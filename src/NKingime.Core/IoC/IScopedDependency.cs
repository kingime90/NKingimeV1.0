using NKingime.Core.Flag;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 继承此接口的类型将被注册为<see cref="LifetimeScopeFlag.Scoped"/>模式。
    /// </summary>
    public interface IScopedDependency : IDependency
    {

    }
}
