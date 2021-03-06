﻿using System;
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
            if (IsNullableType(type))
            {
                var nullableConverter = new NullableConverter(type);
                return nullableConverter.UnderlyingType;
            }
            //
            return type;
        }
    }
}
