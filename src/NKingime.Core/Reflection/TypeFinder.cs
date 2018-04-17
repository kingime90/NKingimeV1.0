using System;
using System.Collections.Generic;
using System.Linq;
using NKingime.Core.Generic;

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
        public TypeFinder() : this(GetAssemblyFinder())
        {

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
        public override IEnumerable<Type> FindAll()
        {
            var assemblys = AssemblyFinder.FindAll();
            return assemblys.SelectMany(assembly => assembly.GetTypes()).Where(p => FinderType.IsAssignableFrom(p)).Distinct();
        }

        /// <summary>
        /// 获取程序集查找器。
        /// </summary>
        /// <returns></returns>
        private static IAssemblyFinder GetAssemblyFinder()
        {
            return new DirectoryAssemblyFinder();
        }
    }
}
