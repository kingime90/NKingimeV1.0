using System;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 定义依赖注入构建器接口。
    /// </summary>
    public interface IIocBuilder
    {
        /// <summary>
        /// 获取服务提供者。
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 开始构建依赖注入映射。
        /// </summary>
        /// <returns>服务提供者</returns>
        IServiceProvider Build();
    }
}
