using System;
using System.Diagnostics;
using NKingime.Core.Option;
using NKingime.Core.Extension;


namespace NKingime.Core.Dependency
{
    /// <summary>
    /// 依赖注入映射描述信息。
    /// </summary>
    [DebuggerDisplay("Lifetime = {Lifetime}, ServiceType = {ServiceType}, ImplementationType = {ImplementationType}")]
    public class ServiceDescriptor
    {
        #region 构造函数

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <param name="lifetime">生命周期。</param>
        public ServiceDescriptor(Type serviceType, Type implementationType, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient) : this(serviceType, lifetime)
        {
            ImplementationType = implementationType;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        public ServiceDescriptor(Type serviceType, object implementationInstance, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient) : this(serviceType, lifetime)
        {
            ImplementationInstance = implementationInstance;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> implementationFactory, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient) : this(serviceType, lifetime)
        {
            ImplementationFactory = implementationFactory;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="lifetime">生命周期。</param>
        private ServiceDescriptor(Type serviceType, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 生命周期。
        /// </summary>
        public LifetimeScopeOption Lifetime { get; private set; }

        /// <summary>
        /// 服务类型。
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// 服务实现类型。
        /// </summary>
        public Type ImplementationType { get; private set; }

        /// <summary>
        /// 服务实现实例。
        /// </summary>
        public object ImplementationInstance { get; private set; }

        /// <summary>
        /// 服务实现实例工厂。
        /// </summary>
        public Func<IServiceProvider, object> ImplementationFactory { get; private set; }

        #endregion

        #region 方法

        /// <summary>
        /// 创建实时模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TService>(Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            return Descriptor<TService>(implementationFactory);
        }

        /// <summary>
        /// 创建实时模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TService>(object implementationInstance) where TService : class
        {
            return Descriptor<TService>(implementationInstance);
        }

        /// <summary>
        /// 创建实时模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TService, TImplementation>() where TService : class where TImplementation : TService
        {
            return Descriptor<TService, TImplementation>();
        }

        /// <summary>
        /// 创建实时模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient(Type serviceType, Type implementationType)
        {
            return Descriptor(serviceType, implementationType);
        }

        /// <summary>
        /// 创建实时模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient(Type serviceType, object implementationInstance)
        {
            return Descriptor(serviceType, implementationInstance);
        }

        /// <summary>
        /// 创建实时模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return Descriptor(serviceType, implementationFactory);
        }

        /// <summary>
        /// 创建局部模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scoped<TService>(Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            return Descriptor<TService>(implementationFactory, LifetimeScopeOption.Scoped);
        }

        /// <summary>
        /// 创建局部模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scoped<TService>(object implementationInstance) where TService : class
        {
            return Descriptor<TService>(implementationInstance, LifetimeScopeOption.Scoped);
        }

        /// <summary>
        /// 创建局部模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Scoped<TService, TImplementation>() where TService : class where TImplementation : TService
        {
            return Descriptor<TService, TImplementation>(LifetimeScopeOption.Scoped);
        }

        /// <summary>
        /// 创建局部模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scoped(Type serviceType, Type implementationType)
        {
            return Descriptor(serviceType, implementationType, LifetimeScopeOption.Scoped);
        }

        /// <summary>
        /// 创建局部模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scoped(Type serviceType, object implementationInstance)
        {
            return Descriptor(serviceType, implementationInstance, LifetimeScopeOption.Scoped);
        }

        /// <summary>
        /// 创建局部模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scoped(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return Descriptor(serviceType, implementationFactory, LifetimeScopeOption.Scoped);
        }

        /// <summary>
        /// 创建单例模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton<TService>(Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            return Descriptor<TService>(implementationFactory, LifetimeScopeOption.Singleton);
        }

        /// <summary>
        /// 创建单例模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton<TService>(object implementationInstance) where TService : class
        {
            return Descriptor<TService>(implementationInstance, LifetimeScopeOption.Singleton);
        }

        /// <summary>
        /// 创建单例模式依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Singleton<TService, TImplementation>() where TService : class where TImplementation : TService
        {
            return Descriptor<TService, TImplementation>(LifetimeScopeOption.Singleton);
        }

        /// <summary>
        /// 创建单例模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton(Type serviceType, Type implementationType)
        {
            return Descriptor(serviceType, implementationType, LifetimeScopeOption.Singleton);
        }

        /// <summary>
        /// 创建单例模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton(Type serviceType, object implementationInstance)
        {
            return Descriptor(serviceType, implementationInstance, LifetimeScopeOption.Singleton);
        }

        /// <summary>
        /// 创建单例模式依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return Descriptor(serviceType, implementationFactory, LifetimeScopeOption.Singleton);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor<TService>(Func<IServiceProvider, object> implementationFactory, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient) where TService : class
        {
            return Descriptor(typeof(TService), implementationFactory, lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor<TService>(object implementationInstance, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient) where TService : class
        {
            return Descriptor(typeof(TService), implementationInstance, lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor<TService, TImplementation>(LifetimeScopeOption lifetime = LifetimeScopeOption.Transient) where TService : class where TImplementation : TService
        {
            return Descriptor(typeof(TService), typeof(TImplementation), lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor(Type serviceType, Type implementationType, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient)
        {
            return new ServiceDescriptor(serviceType, implementationType, lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor(Type serviceType, object implementationInstance, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient)
        {
            return new ServiceDescriptor(serviceType, implementationInstance, lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor(Type serviceType, Func<IServiceProvider, object> implementationFactory, LifetimeScopeOption lifetime = LifetimeScopeOption.Transient)
        {
            return new ServiceDescriptor(serviceType, implementationFactory, lifetime);
        }

        #endregion

        #region 重写

        /// <summary>
        /// 确定指定的 System.Object 是否等于当前的 System.Object。
        /// </summary>
        /// <param name="obj">与当前的 System.Object 进行比较的 System.Object。</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this.IsNull() || obj.IsNull())
            {
                return false;
            }
            //
            var descriptor = obj as ServiceDescriptor;
            if (descriptor.IsNull())
            {
                return false;
            }
            //
            return ServiceType == descriptor.ServiceType && ImplementationType == descriptor.ImplementationType;
        }

        #endregion
    }
}
