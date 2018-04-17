using System;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace NKingime.Entity.Data
{
    /// <summary>
    /// 数据实体映射接口。
    /// </summary>
    public interface IEntityMapper
    {
        /// <summary>
        /// 数据库上下文类型。
        /// </summary>
        Type DbContextType { get; }

        /// <summary>
        /// 将数据实体映射对象注册到当前数据访问上下文实体映射配置注册器中。
        /// </summary>
        /// <param name="configurations">实体映射配置注册器。</param>
        void RegistTo(ConfigurationRegistrar configurations);
    }
}
