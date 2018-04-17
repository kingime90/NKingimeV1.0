using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using NKingime.Core.Generic;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 目录程序集查找器。
    /// </summary>
    public class DirectoryAssemblyFinder : FinderBase<Assembly>, IAssemblyFinder
    {
        /// <summary>
        /// 程序集集合缓存。
        /// </summary>
        private static readonly IDictionary<string, IEnumerable<Assembly>> AssemblyCache;

        private readonly string _path;

        static DirectoryAssemblyFinder()
        {
            AssemblyCache = new Dictionary<string, IEnumerable<Assembly>>();
        }

        /// <summary>
        /// 初始化一个<see cref="DirectoryAssemblyFinder"/>类型的新实例。
        /// </summary>
        public DirectoryAssemblyFinder() : this(GetBinPath())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DirectoryAssemblyFinder"/>类型的新实例。
        /// </summary>
        /// <param name="path">要查找的路径。</param>
        public DirectoryAssemblyFinder(string path)
        {
            _path = path;
        }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Assembly> FindAll()
        {
            IEnumerable<Assembly> assemblys;
            if (AssemblyCache.TryGetValue(_path, out assemblys))
            {
                return assemblys;
            }
            var files = Directory.GetFiles(_path, "*.dll", SearchOption.TopDirectoryOnly).Concat(Directory.GetFiles(_path, "*.exe", SearchOption.TopDirectoryOnly)).Distinct();
            assemblys = files.Select(s => Assembly.LoadFile(s)).Distinct().ToList();
            AssemblyCache.Add(_path, assemblys);
            return assemblys;
        }

        /// <summary>
        /// 获取Bin目录路径。
        /// </summary>
        /// <returns></returns>
        private static string GetBinPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
