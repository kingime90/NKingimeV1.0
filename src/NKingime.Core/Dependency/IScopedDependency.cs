using NKingime.Core.Option;

namespace NKingime.Core.Dependency
{
    /// <summary>
    /// 继承此接口的类型将被注册为<see cref="LifetimeScopeOption.Scoped"/>模式。
    /// </summary>
    public interface IScopedDependency : IDependency
    {

    }
}
