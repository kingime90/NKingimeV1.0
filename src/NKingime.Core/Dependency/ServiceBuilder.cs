using System;
using System.Linq;
using System.Collections.Generic;
using NKingime.Core.Option;
using NKingime.Core.Extension;
using NKingime.Core.Reflection;

namespace NKingime.Core.Dependency
{
    /// <summary>
    /// 服务构建器。
    /// </summary>
    public class ServiceBuilder : IServiceBuilder
    {
        /// <summary>
        /// 初始化一个<see cref="ServiceBuilder"/>类型的新实例。
        /// </summary>
        public ServiceBuilder()
        {
            TransientTypeFinder = new TransientDependencyTypeFinder();
            ScopedTypeFinder = new ScopedDependencyTypeFinder();
            SingletonTypeFinder = new SingletonDependencyTypeFinder();
            ExceptInterfaceTypes = new Type[]
            {
                typeof(IDependency),
                typeof(ITransientDependency),
                typeof(IScopedDependency),
                typeof(ISingletonDependency),
            };
        }

        /// <summary>
        /// 实时模式依赖注入接口类型查找器。
        /// </summary>
        public ITypeFinder TransientTypeFinder { get; private set; }

        /// <summary>
        /// 局部模式依赖注入接口类型查找器。
        /// </summary>
        public ITypeFinder ScopedTypeFinder { get; private set; }

        /// <summary>
        /// 单例模式依赖注入接口类型查找器。
        /// </summary>
        public ITypeFinder SingletonTypeFinder { get; private set; }

        /// <summary>
        /// 排除的接口类型数组。
        /// </summary>
        public Type[] ExceptInterfaceTypes { get; private set; }

        /// <summary>
        /// 构建。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        public void Build(IServiceCollection collection)
        {
            var implementationTypes = TransientTypeFinder.FindAll().ToList();
            AddServiceDescriptor(collection, implementationTypes, LifetimeOption.Transient);

            implementationTypes = ScopedTypeFinder.FindAll().ToList();
            AddServiceDescriptor(collection, implementationTypes, LifetimeOption.Scoped);

            implementationTypes = SingletonTypeFinder.FindAll().ToList();
            AddServiceDescriptor(collection, implementationTypes, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 添加依赖注入映射描述信息。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationTypes">服务实现类型序列。</param>
        /// <param name="lifetime">生命周期。</param>
        protected void AddServiceDescriptor(IServiceCollection collection, IEnumerable<Type> implementationTypes, LifetimeOption lifetime)
        {
            Type[] interfaceTypes;
            foreach (var implementationType in implementationTypes)
            {
                if (implementationType.IsAbstract || implementationType.IsInterface)
                {
                    continue;
                }
                //
                interfaceTypes = GetImplementedInterfaces(implementationType);
                if (interfaceTypes.Length == 0)
                {
                    collection.Add(implementationType, implementationType, lifetime);
                    continue;
                }
                foreach (var interfaceType in interfaceTypes)
                {
                    collection.Add(interfaceType, implementationType, lifetime);
                }
            }
        }

        /// <summary>
        /// 获取指定类型实现或继承的接口数组。
        /// </summary>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        protected Type[] GetImplementedInterfaces(Type implementationType)
        {
            var interfaceTypes = implementationType.GetInterfaces().Where(p => !ExceptInterfaceTypes.Contains(p)).ToArray();
            int length = interfaceTypes.Length;
            Type interfaceType;
            for (int i = 0; i < length; i++)
            {
                interfaceType = interfaceTypes[i];
                if (interfaceType.IsGenericType && !interfaceType.IsGenericTypeDefinition && interfaceType.FullName.IsNull())
                {
                    interfaceTypes[i] = interfaceType.GetGenericTypeDefinition();
                }
            }
            return interfaceTypes;
        }
    }
}
