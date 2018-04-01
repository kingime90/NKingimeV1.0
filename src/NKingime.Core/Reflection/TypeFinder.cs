using System;
using System.Collections.Generic;
using System.Linq;
using NKingime.Core.Public;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 类型查找器。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TypeFinder<T> : FinderBase<Type>, ITypeFinder<T>
    {
        /// <summary>
        /// 初始化一个<see cref="TypeFinder{T}"/>类型的新实例。
        /// </summary>
        public TypeFinder()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 初始化一个<see cref="TypeFinder{T}"/>类型的新实例。
        /// </summary>
        /// <param name="assemblyFinder"></param>
        public TypeFinder(IAssemblyFinder assemblyFinder)
        {
            AssemblyFinder = assemblyFinder;
        }

        /// <summary>
        /// 程序集查找器。
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; private set; }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Type> FindAll()
        {
            var type = typeof(T);
            var assemblys = AssemblyFinder.FindAll();
            return assemblys.SelectMany(assembly => assembly.GetTypes()).Where(p => type.IsAssignableFrom(p)).Distinct();
        }
    }
}
