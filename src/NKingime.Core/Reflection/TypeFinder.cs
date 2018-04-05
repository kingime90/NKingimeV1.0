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
        /// 类型集合缓存。
        /// </summary>
        private static readonly IDictionary<Type, IEnumerable<Type>> TypeSet;

        static TypeFinder()
        {
            TypeSet = new Dictionary<Type, IEnumerable<Type>>();
        }

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
            FinderType = typeof(T);
        }

        /// <summary>
        /// 程序集查找器。
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; private set; }

        /// <summary>
        /// 查找的类型。
        /// </summary>
        public Type FinderType { get; private set; }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Type> FindAll()
        {
            IEnumerable<Type> types;
            if (TypeSet.TryGetValue(FinderType, out types))
            {
                return types;
            }
            var assemblys = AssemblyFinder.FindAll();
            types = assemblys.SelectMany(assembly => assembly.GetTypes()).Where(p => FinderType.IsAssignableFrom(p)).Distinct();
            TypeSet.Add(FinderType, types);
            return types;
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
