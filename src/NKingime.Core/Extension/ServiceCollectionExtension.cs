using NKingime.Core.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 依赖注入映射描述信息集合扩展方法。
    /// </summary>
    public static class ServiceCollectionExtension
    {


        /// <summary>
        /// 尝试添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="descriptor">服务映射信息。</param>
        public static IServiceCollection TryAdd(IServiceCollection collection, ServiceDescriptor descriptor)
        {
            var service = collection.FirstOrDefault(p => p.Equals(descriptor));
            if (service != null)
            {
                collection.Remove(service);
            }
            collection.Add(descriptor);
            return collection;
        }
    }
}
