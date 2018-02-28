﻿using NKingime.Core.Extension;
using System;

namespace NKingime.Core.Utility
{
    /// <summary>
    /// 类型转换应用。
    /// </summary>
    public static class TypeConvertUtil
    {
        /// <summary>
        /// 把对象类型转化为指定类型。
        /// </summary>
        /// <typeparam name="T">动态类型。</typeparam>
        /// <param name="value">要转化的源对象。</param>
        /// <returns>转化后的指定类型的对象，转化失败引发异常。</returns>
        public static T CastTo<T>(object value)
        {
            if (value == null && default(T) == null)
            {
                return default(T);
            }
            var type = typeof(T);
            if (value.GetType() == type)
            {
                return (T)value;
            }
            var result = CastTo(value, type);
            return (T)result;
        }

        /// <summary>
        /// 把对象类型转换为指定类型。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static object CastTo(object value, Type conversionType)
        {
            if (value == null)
            {
                return null;
            }
            if (conversionType.IsNullableType())
            {
                conversionType = conversionType.GetUnNullableType();
            }
            if (conversionType.IsEnum)
            {
                return Enum.Parse(conversionType, value.ToString());
            }
            if (conversionType == typeof(Guid))
            {
                return Guid.Parse(value.ToString());
            }
            return Convert.ChangeType(value, conversionType);
        }
    }
}
