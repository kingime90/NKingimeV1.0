using System;
using System.Collections.Generic;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 定义依赖注入映射描述信息集合接口。
    /// </summary>
    public interface IServiceCollection : IList<ServiceDescriptor>
    {
        /// <summary>
        /// 克隆创建当前集合的副本。
        /// </summary>
        /// <returns></returns>
        IServiceCollection Clone();
    }
}
