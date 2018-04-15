using System;

namespace NKingime.Core.Utility
{
    /// <summary>
    /// 异常应用。
    /// </summary>
    public static class ExceptionUtil
    {
        /// <summary>
        /// 创建异常对象。
        /// </summary>
        /// <typeparam name="TException">异常类型。</typeparam>
        /// <param name="args">与要调用构造函数的参数数量、顺序和类型匹配的参数数组。如果 args 为空数组或 null，则调用不带任何参数的构造函数（默认构造函数）。</param>
        /// <returns></returns>
        public static TException CreateException<TException>(params object[] args) where TException : Exception
        {
            return (TException)Activator.CreateInstance(typeof(TException), args);
        }
    }
}
