using System;
using NKingime.Core.Extension;

namespace NKingime.Core.Utility
{
    /// <summary>
    /// 类型转换工具。
    /// </summary>
    public static class TypeConvertUtil
    {
        /// <summary>
        /// 将指定的值转换为指定的类型。
        /// </summary>
        /// <typeparam name="T">泛型类型。</typeparam>
        /// <param name="value">要转换的值。</param>
        /// <returns></returns>
        public static T CastTo<T>(object value)
        {
            if (value.IsNull() && default(T).IsNull())
            {
                return default(T);
            }
            //
            var type = typeof(T);
            if (value.GetType() == type)
            {
                return (T)value;
            }
            //
            return (T)CastTo(value, type);
        }

        /// <summary>
        /// 将指定的值转换为指定的类型。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="conversionType">要转换的类型。</param>
        /// <returns></returns>
        public static object CastTo(object value, Type conversionType)
        {
            if (value.IsNull())
            {
                return null;
            }
            //
            conversionType = conversionType.GetUnNullableType();
            //
            if (conversionType.IsEnum)
            {
                return Enum.Parse(conversionType, value.ToString());
            }
            //
            if (conversionType == typeof(Guid))
            {
                return Guid.Parse(value.ToString());
            }
            //
            return Convert.ChangeType(value, conversionType);
        }
    }
}
