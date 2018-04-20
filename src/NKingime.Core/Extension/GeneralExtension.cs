using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
using NKingime.Core.Flag;
using NKingime.Core.Utility;
using System.Linq;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 常规扩展方法（泛型 + object + Nullable<>）。
    /// </summary>
    public static class GeneralExtension
    {
        #region 泛型（T）

        /// <summary>
        /// 指示指定的类型是否为 null。
        /// </summary>
        /// <typeparam name="T">要测试的类型。</typeparam>
        /// <param name="t">类型实例。</param>
        /// <returns>如果 t 参数为 null，则为 true；否则为 false。</returns>
        public static bool IsNull<T>(this T t)
        {
            return t == null;
        }

        /// <summary>
        /// 指示指定的类型是否不为 null。
        /// </summary>
        /// <typeparam name="T">要测试的类型。</typeparam>
        /// <param name="t">类型实例。</param>
        /// <returns>如果 t 参数不为 null，则为 true；否则为 false。</returns>
        public static bool IsNotNull<T>(this T t)
        {
            return !t.IsNull();
        }

        /// <summary>
        /// 获取指定类型实例或默认实例。
        /// </summary>
        /// <typeparam name="T">要获取的类型。</typeparam>
        /// <param name="t">要获取的类型实例。</param>
        /// <param name="defVal">默认类型实例。</param>
        /// <returns>如果 t 参数不为 null，则为 t；如果 defVal 参数不为 null，则为 defVal；否则为 default(T)。</returns>
        public static T GetOrDefault<T>(this T t, T defVal)
        {
            if (t.IsNotNull())
            {
                return t;
            }
            //
            if (defVal.IsNotNull())
            {
                return defVal;
            }
            //
            return default(T);
        }

        /// <summary>
        /// 指示指定的值是不是在指定的范围内。
        /// </summary>
        /// <typeparam name="T">要测试的类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        /// <param name="compareFlag">比较标识，默认大于等于和小于等于。</param>
        /// <returns></returns>
        public static bool IsRange<T>(this T value, T minValue, T maxValue, CompareFlag compareFlag = CompareFlag.GreaterEqualAndLessEqual) where T : struct, IComparable
        {
            bool result = false;
            switch (compareFlag)
            {
                case CompareFlag.GreaterAndLess:
                    result = value.IsGreater(minValue) && value.IsLess(maxValue);
                    break;
                case CompareFlag.GreaterEqualAndLessEqual:
                    result = value.IsGreaterEqual(maxValue) && value.IsLessEqual(maxValue);
                    break;
                case CompareFlag.GreaterAndLessEqual:
                    result = value.IsGreater(minValue) && value.IsLessEqual(maxValue);
                    break;
                case CompareFlag.GreaterEqualAndLess:
                    result = value.IsGreaterEqual(maxValue) && value.IsLess(maxValue);
                    break;
            }
            return result;
        }

        /// <summary>
        /// 指示指定的值是否大于另一个值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static bool IsGreater<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) > 0;
        }

        /// <summary>
        /// 指示指定的值是否大于等于另一个值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static bool IsGreaterEqual<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) >= 0;
        }

        /// <summary>
        /// 指示指定的值是否小于另一个值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static bool IsLess<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) < 0;
        }

        /// <summary>
        /// 指示指定的值是否小于等于另一个值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static bool IsLessEqual<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) <= 0;
        }

        /// <summary>
        /// 序列是否为 null 或 空。
        /// </summary>
        /// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        /// <param name="source">要测试的序列。</param>
        /// <returns></returns>
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source.IsNull() || Enumerable.Count(source) == 0;
        }

        /// <summary>
        /// 序列是否不为 null 或 空。
        /// </summary>
        /// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        /// <param name="source">要测试的序列。</param>
        /// <returns></returns>
        public static bool IsNotEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return !source.IsEmpty();
        }

        /// <summary>
        /// 数组是否为 null 或 空。
        /// </summary>
        /// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        /// <param name="source">要测试的数组。</param>
        /// <returns></returns>
        public static bool IsEmpty<TSource>(this TSource[] source)
        {
            return source.IsNull() || source.Length == 0;
        }

        /// <summary>
        /// 数组是否不为 null 或 空。
        /// </summary>
        /// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        /// <param name="source">要测试的数组。</param>
        /// <returns></returns>
        public static bool IsNotEmpty<TSource>(this TSource[] source)
        {
            return !source.IsEmpty();
        }

        /// <summary>
        /// 如果指定属性存在，则设置指定类型的属性的值。
        /// </summary>
        /// <typeparam name="TSource">source 类型。</typeparam>
        /// <typeparam name="TElement">source 类型的基类型。</typeparam>
        /// <typeparam name="TProperty">source 类型的基类型的属性类型。</typeparam>
        /// <param name="source">要设置的类型的实例。</param>
        /// <param name="propertySelector">用于从元素中提取属性的函数。</param>
        /// <param name="value">设置的值。</param>
        public static void SetPropertyValue<TSource, TElement, TProperty>(this TSource source, Expression<Func<TElement, TProperty>> propertySelector, TProperty value) where TSource : class where TElement : class
        {
            if (!(source is TElement))
            {
                return;
            }
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            propertyInfo.SetValue(source, value);
        }

        #endregion

        #region object

        /// <summary>
        /// 将指定的值转换为指定的类型。
        /// </summary>
        /// <typeparam name="T">泛型类型。</typeparam>
        /// <param name="value">要转换的值。</param>
        /// <returns></returns>
        public static T CastTo<T>(this object value)
        {
            return TypeConvertUtil.CastTo<T>(value);
        }

        /// <summary>
        /// 将指定的值转换为指定的类型。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="conversionType">要转换的类型。</param>
        /// <returns></returns>
        public static object CastTo(this object value, Type conversionType)
        {
            return TypeConvertUtil.CastTo(value, conversionType);
        }

        #endregion

        #region 可空类型 Nullable<>

        #region 可空布尔值（bool?）


        /// <summary>
        /// 指示指定的可空布尔值是否为 true。
        /// </summary>
        /// <param name="value">要测试的可空布尔值。</param>
        /// <returns></returns>
        public static bool IsTrue(this bool? value)
        {
            return value.HasValue && value.Value;
        }

        /// <summary>
        /// 指示指定的可空布尔值是否为 false。
        /// </summary>
        /// <param name="value">要测试的可空布尔值。</param>
        /// <returns></returns>
        public static bool IsFalse(this bool? value)
        {
            return !value.IsTrue();
        }

        #endregion

        #endregion

    }
}