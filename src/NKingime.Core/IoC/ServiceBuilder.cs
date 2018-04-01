using System;
using System.Collections.Generic;
using System.Linq;
using NKingime.Core.Reflection;
using NKingime.Core.Flag;

namespace NKingime.Core.IoC
{
    /// <summary>
    /// 服务构建器。
    /// </summary>
    public class ServiceBuilder : IServiceBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        public ServiceBuilder()
        {
            TransientTypeFinder = new TypeFinder<ITransientDependency>();
            ScopedTypeFinder = new TypeFinder<IScopedDependency>();
            SingletonTypeFinder = new TypeFinder<ISingletonDependency>();
        }

        /// <summary>
        /// 实时模式依赖注入接口类型查找器。
        /// </summary>
        public ITypeFinder<ITransientDependency> TransientTypeFinder { get; private set; }

        /// <summary>
        /// 局部模式依赖注入接口类型查找器。
        /// </summary>
        public ITypeFinder<IScopedDependency> ScopedTypeFinder { get; private set; }

        /// <summary>
        /// 单例模式依赖注入接口类型查找器。
        /// </summary>
        public ITypeFinder<ISingletonDependency> SingletonTypeFinder { get; private set; }

        /// <summary>
        /// 构建。
        /// </summary>
        /// <param name="services">依赖注入映射描述信息集合接口。</param>
        public void Build(IServiceCollection descriptors)
        {
            var implementationTypes = TransientTypeFinder.FindAll();
            AddServiceDescriptor(descriptors, implementationTypes, LifetimeScopeFlag.Transient);

            implementationTypes = ScopedTypeFinder.FindAll();
            AddServiceDescriptor(descriptors, implementationTypes, LifetimeScopeFlag.Scoped);

            implementationTypes = SingletonTypeFinder.FindAll();
            AddServiceDescriptor(descriptors, implementationTypes, LifetimeScopeFlag.Singleton);
        }

        /// <summary>
        /// 添加依赖注入映射描述信息。
        /// </summary>
        /// <param name="descriptors">依赖注入映射描述信息集合。</param>
        /// <param name="implementationTypes">实现类型集合。</param>
        /// <param name="lifetime">生命周期。</param>
        protected void AddServiceDescriptor(IServiceCollection descriptors, IEnumerable<Type> implementationTypes, LifetimeScopeFlag lifetime)
        {
            foreach (var type in implementationTypes)
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }
                //

            }
        }
    }
}
