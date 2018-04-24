using System;
using System.Collections.Generic;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 服务提供者扩展方法。
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// 获取指定类型服务的实例
        /// </summary>
        /// <typeparam name="T">要获取实例的服务类型</typeparam>
        /// <param name="provider">服务提供者</param>
        /// <returns>指定类型的实例</returns>
        public static T GetService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {

            }
            return (T)provider.GetService(typeof(T));
        }

        /// <summary>
        /// 获取指定类型服务的非空实例
        /// </summary>
        /// <param name="provider">服务提供者</param>
        /// <param name="serviceType">要获取实例的服务类型</param>
        /// <returns>指定类型的非空实例</returns>
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {

            }
            object value = provider.GetService(serviceType);
            if (value == null)
            {

            }
            return value;
        }

        /// <summary>
        /// 获取指定类型服务的非空实例
        /// </summary>
        /// <typeparam name="T">要获取实例的服务类型</typeparam>
        /// <param name="provider">服务提供者</param>
        /// <returns>指定类型的非空实例</returns>
        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {

            }
            return (T)GetRequiredService(provider, typeof(T));
        }

        /// <summary>
        /// 获取指定类型服务的所有实例
        /// </summary>
        /// <typeparam name="T">要获取实例的服务类型</typeparam>
        /// <param name="provider">服务提供者</param>
        /// <returns>指定类型的所有实例</returns>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {

            }
            return provider.GetRequiredService<IEnumerable<T>>();
        }

        /// <summary>
        /// 获取指定类型服务的所有实例
        /// </summary>
        /// <param name="provider">服务提供者</param>
        /// <param name="serviceType">要获取实例的服务类型</param>
        /// <returns>指定类型的所有实例</returns>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {

            }
            Type genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }
    }
}