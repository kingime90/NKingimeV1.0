using System;
using System.Linq;
using NKingime.Core.Option;
using NKingime.Core.Dependency;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 依赖注入映射描述信息集合扩展方法。
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        public static void AddTransient(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            collection.TryAdd(ServiceDescriptor.Transient(serviceType, implementationType));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddTransient(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            collection.TryAdd(ServiceDescriptor.Transient(serviceType, implementationInstance));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static void AddTransient(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            collection.TryAdd(ServiceDescriptor.Transient(serviceType, implementationFactory));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        public static void AddTransient<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : TService
        {
            collection.TryAdd(ServiceDescriptor.Transient<TService, TImplementation>());
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddTransient<TService>(this IServiceCollection collection, object implementationInstance) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Transient<TService>(implementationInstance));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static void AddTransient<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Transient<TService>(implementationFactory));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        public static void AddScoped(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            collection.TryAdd(ServiceDescriptor.Scoped(serviceType, implementationType));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddScoped(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            collection.TryAdd(ServiceDescriptor.Scoped(serviceType, implementationInstance));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static void AddScoped(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            collection.TryAdd(ServiceDescriptor.Scoped(serviceType, implementationFactory));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        public static void AddScoped<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : TService
        {
            collection.TryAdd(ServiceDescriptor.Scoped<TService, TImplementation>());
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddScoped<TService>(this IServiceCollection collection, object implementationInstance) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Scoped<TService>(implementationInstance));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static void AddScoped<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Scoped<TService>(implementationFactory));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddSingleton<TService>(this IServiceCollection collection, TService instance) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Singleton<TService>(instance));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        public static void AddSingleton(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            collection.TryAdd(ServiceDescriptor.Singleton(serviceType, implementationType));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddSingleton(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            collection.TryAdd(ServiceDescriptor.Singleton(serviceType, implementationInstance));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static void AddSingleton(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            collection.TryAdd(ServiceDescriptor.Singleton(serviceType, implementationFactory));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        public static void AddSingleton<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : TService
        {
            collection.TryAdd(ServiceDescriptor.Singleton<TService, TImplementation>());
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static void AddSingleton<TService>(this IServiceCollection collection, object implementationInstance) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Singleton<TService>(implementationInstance));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static void AddSingleton<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Singleton<TService>(implementationFactory));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <param name="lifetime">生命周期。</param>
        public static void Add(this IServiceCollection collection, Type serviceType, Type implementationType, LifetimeScopeOption lifetime)
        {
            collection.TryAdd(ServiceDescriptor.Descriptor(serviceType, implementationType, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        public static void Add(this IServiceCollection collection, Type serviceType, object implementationInstance, LifetimeScopeOption lifetime)
        {
            collection.TryAdd(ServiceDescriptor.Descriptor(serviceType, implementationInstance, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        public static void Add(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory, LifetimeScopeOption lifetime)
        {
            collection.TryAdd(ServiceDescriptor.Descriptor(serviceType, implementationFactory, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="lifetime">生命周期。</param>
        public static void Add<TService, TImplementation>(this IServiceCollection collection, LifetimeScopeOption lifetime) where TService : class where TImplementation : TService
        {
            collection.TryAdd(ServiceDescriptor.Descriptor<TService, TImplementation>(lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        public static void Add<TService>(this IServiceCollection collection, object implementationInstance, LifetimeScopeOption lifetime) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Descriptor<TService>(implementationInstance, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        public static void Add<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory, LifetimeScopeOption lifetime) where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Descriptor<TService>(implementationFactory, lifetime));
        }

        /// <summary>
        /// 尝试添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="descriptor">服务映射信息。</param>
        public static void TryAdd(this IServiceCollection collection, ServiceDescriptor descriptor)
        {
            var service = collection.FirstOrDefault(p => p.Equals(descriptor));
            if (service.IsNotNull())
            {
                collection.Remove(service);
            }
            collection.Add(descriptor);
        }
    }
}
