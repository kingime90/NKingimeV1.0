using System;
using System.Reflection;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Builder;
using NKingime.Core.IoC;
using NKingime.Core.Flag;
using NKingime.Core.Extension;

namespace NKingime.Web.Extension
{
    /// <summary>
    /// Autofac类型映射注册操作类。
    /// </summary>
    public static class AutofacRegistration
    {
        /// <summary>
        /// 使用<see cref="ServiceDescriptor"/>映射信息进行类型注册。
        /// </summary>
        /// <param name="builder">容器构建器。</param>
        /// <param name="descriptors">类型映射描述信息集合。</param>
        public static void Populate(this ContainerBuilder builder, IEnumerable<ServiceDescriptor> descriptors)
        {
            builder.RegisterType<IocServiceProvider>().As<IServiceProvider>().SingleInstance();

            RegisterInternal(builder, descriptors);
        }

        private static void RegisterInternal(ContainerBuilder builder, IEnumerable<ServiceDescriptor> descriptors)
        {
            foreach (ServiceDescriptor descriptor in descriptors)
            {
                if (descriptor.ImplementationType != null)
                {
                    TypeInfo serviceTypeInfo = descriptor.ServiceType.GetTypeInfo();
                    if (serviceTypeInfo.IsGenericTypeDefinition)
                    {
                        if (!descriptor.ServiceType.IsGenericAssignableFrom(descriptor.ImplementationType))
                        {

                        }
                        builder.RegisterGeneric(descriptor.ImplementationType)
                            .As(descriptor.ServiceType)
                            .AsSelf()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                            .ConfigureLifetimeStyle(descriptor.Lifetime);
                    }
                    else
                    {
                        if (!descriptor.ServiceType.IsAssignableFrom(descriptor.ImplementationType))
                        {

                        }
                        builder.RegisterType(descriptor.ImplementationType)
                            .As(descriptor.ServiceType)
                            .AsSelf()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                            .ConfigureLifetimeStyle(descriptor.Lifetime);
                    }
                }
                else if (descriptor.ImplementationFactory != null)
                {
                    IComponentRegistration registration = RegistrationBuilder.ForDelegate(descriptor.ServiceType,
                        (context, paramters) =>
                        {
                            IServiceProvider provider = context.Resolve<IServiceProvider>();
                            return descriptor.ImplementationFactory(provider);
                        })
                        .ConfigureLifetimeStyle(descriptor.Lifetime)
                        .CreateRegistration();
                    builder.RegisterComponent(registration);
                }
                else if (descriptor.ImplementationInstance != null)
                {
                    builder.RegisterInstance(descriptor.ImplementationInstance)
                        .As(descriptor.ServiceType)
                        .AsSelf()
                        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                        .ConfigureLifetimeStyle(descriptor.Lifetime);
                }
            }
        }

        private static IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> ConfigureLifetimeStyle<TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> builder,
            LifetimeScopeFlag lifetime)
        {
            switch (lifetime)
            {
                case LifetimeScopeFlag.Transient:
                    builder.InstancePerDependency();
                    break;
                case LifetimeScopeFlag.Scoped:
                    builder.InstancePerLifetimeScope();
                    break;
                case LifetimeScopeFlag.Singleton:
                    builder.SingleInstance();
                    break;
            }
            return builder;
        }
    }
}