using System;
using NKingime.Core.Flag;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 字符串扩展方法。
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或 System.String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 获取字符串。
        /// </summary>
        /// <param name="value">要获取的字符串。</param>
        /// <param name="defVal">默认字符串。</param>
        /// <returns>如果 value 参数不为 null，则为 value；如果 defVal 参数不为 null，则为 defVal；否则为 null（default(System.String)）。</returns>
        public static string GetString(this string value, string defVal = "")
        {
            return value.GetOrDefault(defVal);
        }

        /// <summary>
        /// 获取移除数组中指定的一组字符后的字符串。
        /// </summary>
        /// <param name="value">要获取的字符串。</param>
        /// <param name="removeFlag">字符移除标识。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns></returns>
        public static string GetString(this string value, StingRemoveFlag removeFlag, params char[] trimChars)
        {
            return value.GetString(string.Empty, removeFlag, trimChars);
        }

        /// <summary>
        /// 获取移除数组中指定的一组字符后的字符串。
        /// </summary>
        /// <param name="value">要获取的字符串。</param>
        /// <param name="defVal">默认字符串。</param>
        /// <param name="removeFlag">字符移除标识。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns></returns>
        public static string GetString(this string value, string defVal, StingRemoveFlag removeFlag, params char[] trimChars)
        {
            return value.GetOrDefault(defVal).Trim(removeFlag, trimChars);
        }

        /// <summary>
        /// 从当前 System.String 对象移除数组中指定的一组字符。
        /// </summary>
        /// <param name="value">目标字符串。</param>
        /// <param name="removeFlag">字符移除标识。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns></returns>
        public static string Trim(this string value, StingRemoveFlag removeFlag, params char[] trimChars)
        {
            switch (removeFlag)
            {
                case StingRemoveFlag.Start:
                    return value.TrimStart(trimChars);
                case StingRemoveFlag.End:
                    return value.TrimEnd(trimChars);
                case StingRemoveFlag.None:
                    return value.Trim(trimChars);
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static string ReplaceStart(this string value, string oldValue, string newValue, StringComparison? comparisonType = null)
        {
            if (value.IsNullOrWhiteSpace() || oldValue.IsNullOrEmpty())
            {
                return value;
            }
            int index = comparisonType.HasValue.IfElse(value.IndexOf(oldValue, comparisonType.Value), value.IndexOf(oldValue));
            if (index == -1)
            {
                return value;
            }
            return newValue + value.Remove(0, oldValue.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static string ReplaceEnd(this string value, string oldValue, string newValue, StringComparison? comparisonType = null)
        {
            if (value.IsNullOrWhiteSpace() || oldValue.IsNullOrEmpty())
            {
                return value;
            }
            int index = comparisonType.HasValue.IfElse(value.LastIndexOf(oldValue, comparisonType.Value), value.LastIndexOf(oldValue));
            if (index == -1)
            {
                return value;
            }
            return value.Substring(0, value.Length - oldValue.Length) + newValue;
        }
    }
}
