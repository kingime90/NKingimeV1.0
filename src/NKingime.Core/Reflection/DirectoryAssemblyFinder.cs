using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using NKingime.Core.Generic;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 目录程序集查找器。
    /// </summary>
    public class DirectoryAssemblyFinder : FinderBase<Assembly>, IAllAssemblyFinder
    {
        /// <summary>
        /// 程序集集合缓存。
        /// </summary>
        private static readonly IDictionary<string, Assembly[]> AssemblyCache;

        private readonly string _path;

        static DirectoryAssemblyFinder()
        {
            AssemblyCache = new Dictionary<string, Assembly[]>();
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
        private DirectoryAssemblyFinder(string path)
        {
            _path = path;
        }

        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override Assembly[] FindAll()
        {
            Assembly[] assemblys;
            if (AssemblyCache.TryGetValue(_path, out assemblys))
            {
                return assemblys;
            }
            var files = Directory.GetFiles(_path, "*.dll", SearchOption.TopDirectoryOnly).Concat(Directory.GetFiles(_path, "*.exe", SearchOption.TopDirectoryOnly)).Distinct().ToArray();
            assemblys = files.Select(s => Assembly.LoadFile(s)).Distinct().ToArray();
            AssemblyCache.Add(_path, assemblys);
            return assemblys;
        }

        /// <summary>
        /// 获取Bin目录路径。
        /// </summary>
        /// <returns></returns>
        private static string GetBinPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return path == Environment.CurrentDirectory + "\\" ? path : Path.Combine(path, "bin");
        }
    }
}
