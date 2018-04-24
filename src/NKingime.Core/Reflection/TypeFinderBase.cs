using System;
using System.Linq;
using NKingime.Core.Generic;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 类型查找器。
    /// </summary>
    /// <typeparam name="T">要查找的类型。</typeparam>
    public abstract class TypeFinderBase<T> : FinderBase<Type>, ITypeFinder
    {
        /// <summary>
        /// 初始化一个<see cref="TypeFinder{T}"/>类型的新实例。
        /// </summary>
        public TypeFinderBase() : this(GetAssemblyFinder())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="TypeFinder{T}"/>类型的新实例。
        /// </summary>
        /// <param name="assemblyFinder">所有程序集查找器。</param>
        private TypeFinderBase(IAllAssemblyFinder assemblyFinder)
        {
            AssemblyFinder = assemblyFinder;
        }

        /// <summary>
        /// 所有程序集查找器。
        /// </summary>
        public IAllAssemblyFinder AssemblyFinder { get; private set; }

        private readonly Type _finderType = typeof(T);

        /// <summary>
        /// 查找的类型。
        /// </summary>
        public Type FinderType
        {
            get
            {
                return _finderType;
            }
        }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override Type[] FindAll()
        {
            var assemblys = AssemblyFinder.FindAll();
            return assemblys.SelectMany(assembly => assembly.GetTypes()).Where(p => FinderType.IsAssignableFrom(p)).Distinct().ToArray();
        }

        /// <summary>
        /// 获取程序集查找器。
        /// </summary>
        /// <returns></returns>
        private static IAllAssemblyFinder GetAssemblyFinder()
        {
            return new DirectoryAssemblyFinder();
        }
    }
}
