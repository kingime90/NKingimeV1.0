using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 程序集查找基类。
    /// </summary>
    public abstract class AssemblyFinderBase : IAssemblyFinder
    {
        /// <summary>
        /// 初始化一个<see cref="DirectoryAssemblyFinder"/>类型的新实例。
        /// </summary>
        /// <param name="path">要查找的路径。</param>
        public IEnumerable<Assembly> Find(Func<Assembly, bool> predicate)
        {
            return FindAll().Where(predicate);
        }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<Assembly> FindAll();
    }
}
