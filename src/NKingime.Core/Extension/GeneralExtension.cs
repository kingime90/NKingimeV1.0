using System;
using NKingime.Core.Flag;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 常规扩展。
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
                    result = value.CompareTo(minValue) > 0 && value.CompareTo(maxValue) < 0;
                    break;
                case CompareFlag.GreaterEqualAndLessEqual:
                    result = value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
                    break;
                case CompareFlag.GreaterAndLessEqual:
                    result = value.CompareTo(minValue) > 0 && value.CompareTo(maxValue) <= 0;
                    break;
                case CompareFlag.GreaterEqualAndLess:
                    result = value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) < 0;
                    break;
            }
            return result;
        }

        #endregion

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

    }
}