using System;
using NKingime.Core.Option;

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
        /// <param name="removeOption">字符移除选项。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns></returns>
        public static string GetString(this string value, StingRemoveOption removeOption, params char[] trimChars)
        {
            return value.GetString(string.Empty, removeOption, trimChars);
        }

        /// <summary>
        /// 获取移除数组中指定的一组字符后的字符串。
        /// </summary>
        /// <param name="value">要获取的字符串。</param>
        /// <param name="defVal">默认字符串。</param>
        /// <param name="removeOption">字符移除选项。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns></returns>
        public static string GetString(this string value, string defVal, StingRemoveOption removeOption, params char[] trimChars)
        {
            return value.GetOrDefault(defVal).Trim(removeOption, trimChars);
        }

        /// <summary>
        /// 从当前 System.String 对象移除数组中指定的一组字符。
        /// </summary>
        /// <param name="value">目标字符串。</param>
        /// <param name="removeOption">字符移除选项。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns></returns>
        public static string Trim(this string value, StingRemoveOption removeOption, params char[] trimChars)
        {
            switch (removeOption)
            {
                case StingRemoveOption.Start:
                    return value.TrimStart(trimChars);
                case StingRemoveOption.End:
                    return value.TrimEnd(trimChars);
                case StingRemoveOption.None:
                    return value.Trim(trimChars);
            }
            return value;
        }

        /// <summary>
        /// 替换指定字符串的开头。
        /// </summary>
        /// <param name="value">要替换的字符串。</param>
        /// <param name="start">匹配开头的字符串。</param>
        /// <param name="replace">要替换出现的 start 的字符串。</param>
        /// <param name="comparisonType">枚举值之一，用于确定如何比较此字符串与 value。</param>
        /// <returns></returns>
        public static string ReplaceStart(this string value, string start, string replace, StringComparison? comparisonType = null)
        {
            if (value.IsNullOrWhiteSpace() || start.IsNullOrEmpty())
            {
                return value;
            }
            var isMatch = comparisonType.HasValue.IfElse(() => value.StartsWith(start, comparisonType.Value), value.StartsWith(start));
            if (!isMatch)
            {
                return value;
            }
            return replace + value.Remove(0, start.Length);
        }

        /// <summary>
        /// 替换指定字符串的尾部。
        /// </summary>
        /// <param name="value">要替换的字符串。</param>
        /// <param name="end">匹配尾部的字符串。</param>
        /// <param name="replace">要替换出现的 end 的字符串。</param>
        /// <param name="comparisonType">枚举值之一，用于确定如何比较此字符串与 value。</param>
        /// <returns></returns>
        public static string ReplaceEnd(this string value, string end, string replace, StringComparison? comparisonType = null)
        {
            if (value.IsNullOrWhiteSpace() || end.IsNullOrEmpty())
            {
                return value;
            }
            var isMatch = comparisonType.HasValue.IfElse(() => value.EndsWith(end, comparisonType.Value), value.EndsWith(end));
            if (!isMatch)
            {
                return value;
            }
            return value.Substring(0, value.Length - end.Length) + replace;
        }

        /// <summary>
        /// 移除指定字符串的开头。
        /// </summary>
        /// <param name="value">要移除的字符串。</param>
        /// <param name="start">匹配开头的字符串。</param>
        /// <param name="comparisonType">枚举值之一，用于确定如何比较此字符串与 value。</param>
        /// <returns></returns>
        public static string RemoveStart(this string value, string start, StringComparison? comparisonType = null)
        {
            return value.ReplaceStart(start, string.Empty, comparisonType);
        }

        /// <summary>
        /// 移除指定字符串的尾部。
        /// </summary>
        /// <param name="value">要移除的字符串。</param>
        /// <param name="end">匹配尾部的字符串。</param>
        /// <param name="comparisonType">枚举值之一，用于确定如何比较此字符串与 value。</param>
        /// <returns></returns>
        public static string RemoveEnd(this string value, string end, StringComparison? comparisonType = null)
        {
            return value.ReplaceEnd(end, string.Empty, comparisonType);
        }
    }
}
