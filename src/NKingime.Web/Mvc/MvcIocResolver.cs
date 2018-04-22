using System;
using System.Web.Mvc;
using System.Collections.Generic;
using NKingime.Core.IoC;

namespace NKingime.Web.Mvc
{
    /// <summary>
    /// Mvc依赖注入对象解析器。
    /// </summary>
    public class MvcIocResolver : IIocResolver
    {
        /// <summary>
        /// 从全局容器中解析对象委托。
        /// </summary>
        public static Func<Type, object> GlobalResolveFunc { private get; set; }

        /// <summary>
        /// 获取指定类型的实例。
        /// </summary>
        /// <typeparam name="T">要获取的类型。</typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            try
            {
                return DependencyResolver.Current.GetService<T>();
            }
            catch (Exception)
            {
                if (GlobalResolveFunc != null)
                {
                    return (T)GlobalResolveFunc(typeof(T));
                }
                return default(T);
            }
        }

        /// <summary>
        /// 获取指定类型的实例。
        /// </summary>
        /// <param name="type">要获取的类型。</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            try
            {
                return DependencyResolver.Current.GetService(type);
            }
            catch (Exception)
            {
                if (GlobalResolveFunc != null)
                {
                    return GlobalResolveFunc(type);
                }
                return null;
            }

        }

        /// <summary>
        /// 获取指定类型的所有实例序列。
        /// </summary>
        /// <typeparam name="T">要获取的类型。</typeparam>
        /// <returns></returns>
        public IEnumerable<T> Resolves<T>()
        {
            return DependencyResolver.Current.GetServices<T>();
        }

        /// <summary>
        /// 获取指定类型的所有实例序列。
        /// </summary>
        /// <param name="type">要获取的类型。</param>
        /// <returns></returns>
        public IEnumerable<object> Resolves(Type type)
        {
            return DependencyResolver.Current.GetServices(type);
        }
    }
}
