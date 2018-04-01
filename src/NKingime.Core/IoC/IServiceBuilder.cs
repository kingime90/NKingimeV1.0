using System;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 服务构建器接口。
    /// </summary>
    public interface IServiceBuilder
    {
        /// <summary>
        /// 构建。
        /// </summary>
        /// <param name="descriptors">依赖注入映射描述信息集合接口。</param>
        void Build(IServiceCollection descriptors);
    }
}
