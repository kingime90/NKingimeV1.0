using System;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 值类型扩展方法。
    /// </summary>
    public static class ValueTypeExtension
    {
        #region 布尔值（bool）

        /// <summary>
        /// 如果否则条件。
        /// </summary>
        /// <typeparam name="T">泛型类型。</typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="trueVal">满足条件的值。</param>
        /// <param name="falseVal">不满足条件的值。</param>
        /// <returns></returns>
        public static T IfElse<T>(this bool assertion, T trueVal, T falseVal)
        {
            return assertion ? trueVal : falseVal;
        }

        #endregion

    }
}
