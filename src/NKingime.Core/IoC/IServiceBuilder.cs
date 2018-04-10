﻿using System;

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
        /// <param name="collection">服务映射信息集合。</param>
        void Build(IServiceCollection collection);
    }
}