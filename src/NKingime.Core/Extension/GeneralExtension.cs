using System;
using NKingime.Core.Flag;
using NKingime.Core.Utility;

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
            return !IsNull(t);
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
            if (IsNotNull(t))
            {
                return t;
            }
            //
            if (IsNotNull(defVal))
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
                    result = IsGreater(value, minValue) && IsLess(value, maxValue);
                    break;
                case CompareFlag.GreaterEqualAndLessEqual:
                    result = IsGreaterEqual(value, maxValue) && IsLessEqual(value, maxValue);
                    break;
                case CompareFlag.GreaterAndLessEqual:
                    result = IsGreater(value, minValue) && IsLessEqual(value, maxValue);
                    break;
                case CompareFlag.GreaterEqualAndLess:
                    result = IsGreaterEqual(value, maxValue) && IsLess(value, maxValue);
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
        public static bool IsTrue(bool? value)
        {
            return value.HasValue && value.Value;
        }

        /// <summary>
        /// 指示指定的可空布尔值是否为 false。
        /// </summary>
        /// <param name="value">要测试的可空布尔值。</param>
        /// <returns></returns>
        public static bool IsFalse(bool? value)
        {
            return !IsTrue(value);
        }

        #endregion

        #endregion

    }
}