using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 类型扩展方法。
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// 判断类型是否为Nullable类型。
        /// </summary>
        /// <param name="type">要处理的类型。</param>
        /// <returns>是返回true，不是返回false。</returns>
        public static bool IsNullableType(this Type type)
        {
            return type.IsNotNull() && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// 通过类型转换器获取Nullable类型的基础类型。
        /// </summary>
        /// <param name="type">要处理的类型对象。</param>
        /// <returns> </returns>
        public static Type GetUnNullableType(this Type type)
        {
            if (type.IsNullableType())
            {
                var nullableConverter = new NullableConverter(type);
                return nullableConverter.UnderlyingType;
            }
            //
            return type;
        }

        /// <summary>
        /// 确定当前的 System.Type 的泛型实例是否可以从指定 Type 的实例分配。
        /// </summary>
        /// <param name="genericType">泛型类型。</param>
        /// <param name="type">与当前泛型类型进行比较的 Type。</param>
        /// <param name="baseType">输出继承的类型。</param>
        /// <returns></returns>
        public static bool IsGenericAssignableFrom(this Type genericType, Type type, out Type baseType)
        {
            baseType = null;
            if (!genericType.IsGenericType)
            {
                return false;
            }
            //
            var implementationTypes = new List<Type>()
            {
                type
            };
            if (genericType.IsInterface)
            {
                implementationTypes.AddRange(type.GetInterfaces());
            }
            Type implementationType;
            var baseTypes = new List<Type>();
            int level;
            foreach (var item in implementationTypes)
            {
                implementationType = item;
                level = 0;
                while (implementationType != null)
                {
                    if (implementationType.IsGenericType)
                    {
                        implementationType = implementationType.GetGenericTypeDefinition();
                    }
                    if (implementationType.IsSubclassOf(genericType) || implementationType == genericType)
                    {
                        return true;
                    }
                    implementationType = implementationType.BaseType;
                    level++;
                    if (level > 1)
                    {
                        baseType = baseType.BaseType;
                    }
                    else
                    {
                        baseType = implementationType;
                    }
                }
            }
            baseType = null;
            return false;
        }

        /// <summary>
        /// 确定当前的 System.Type 的泛型实例是否可以从指定 Type 的实例分配。
        /// </summary>
        /// <param name="genericType">泛型类型。</param>
        /// <param name="type">与当前泛型类型进行比较的 Type。</param>
        /// <returns></returns>
        public static bool IsGenericAssignableFrom(this Type genericType, Type type)
        {
            Type baseType;
            return genericType.IsGenericAssignableFrom(type, out baseType);
        }

        /// <summary>
        /// 指定当前类型是否实现指定基类。
        /// </summary>
        /// <param name="type">当前类型。</param>
        /// <param name="baseType">基类。</param>
        /// <returns></returns>
        public static bool IsImplementOf(this Type type, Type baseType)
        {
            if (type.IsGenericTypeDefinition)
            {
                return baseType.IsGenericAssignableFrom(type);
            }
            return baseType.IsAssignableFrom(type);
        }
    }
}
