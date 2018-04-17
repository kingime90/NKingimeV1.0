using System;
using NKingime.Core.Utility;
using System.Collections.Generic;

namespace NKingime.Core.Extension
{
    /// <summary>
    /// 验证扩展方法。
    /// </summary>
    public static class ValidationExtension
    {
        /// <summary>
        /// 检查参数不能为空引用，否则抛出<see cref="ArgumentNullException"/>异常。
        /// </summary>
        /// <typeparam name="T">参数类型。</typeparam>
        /// <param name="argument">参数实例。</param>
        /// <param name="paramName">获取导致异常的参数名称委托。</param>
        /// <param name="message">描述错误的消息。</param>
        public static void CheckNotNull<T>(this T argument, Func<string> paramName, string message = null)
        {
            if (argument.IsNotNull())
            {
                return;
            }
            string paramNameValue;
            if (paramName.IsNull() || (paramNameValue = paramName()).IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(paramName));
            }
            ArgumentNullException exception;
            if (!message.IsNullOrWhiteSpace())
            {
                exception = new ArgumentNullException(paramNameValue, message);
            }
            else
            {
                exception = new ArgumentNullException(paramNameValue);
            }
            throw exception;
        }

        /// <summary>
        /// 检查参数不能为空引用，否则抛出<see cref="ArgumentNullException"/>异常。
        /// </summary>
        /// <typeparam name="T">参数类型。</typeparam>
        /// <param name="argument">参数实例。</param>
        /// <param name="paramName">导致异常的参数名称。</param>
        /// <param name="message">描述错误的消息。</param>
        public static void CheckNotNull<T>(this T argument, string paramName, string message = null)
        {
            var args = new List<object>();
            if (paramName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(paramName));
            }
            ArgumentNullException exception;
            if (!message.IsNullOrWhiteSpace())
            {
                exception = new ArgumentNullException(paramName, message);
            }
            else
            {
                exception = new ArgumentNullException(paramName);
            }
            throw exception;
        }

        /// <summary>
        /// 验证指定值的断言<paramref name="assertion"/>是否为真，如果不为真，抛出指定消息<paramref name="message"/>的指定类型<typeparamref name="TException"/>异常。
        /// </summary>
        /// <typeparam name="TException">异常类型。</typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="args">与要调用构造函数的参数数量、顺序和类型匹配的参数数组。如果 args 为空数组或 null，则调用不带任何参数的构造函数（默认构造函数）。</param>
        public static void Require<TException>(bool assertion, params object[] args) where TException : Exception
        {
            if (assertion)
            {
                return;
            }
            if (args.IsNull())
            {
                throw new ArgumentNullException(nameof(args));
            }
            throw ExceptionUtil.CreateException<TException>(args);
        }
    }
}
