using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using NKingime.Core.Reflection;
using NKingime.Core.Extension;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据库上下文初始化配置。
    /// </summary>
    public class DbContextInitializerConfig
    {
        /// <summary>
        /// 初始化一个<see cref="DbContextInitializerConfig"/>类型的新实例。
        /// </summary>
        private DbContextInitializerConfig()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
            _mapperAssemblys = new List<Assembly>();
        }

        /// <summary>
        /// 初始化一个<see cref="DbContextInitializerConfig"/>类型的新实例。
        /// </summary>
        /// <param name="element"></param>
        public DbContextInitializerConfig(DbContextInitializerElement element) : this()
        {
            InitializerType = Type.GetType(element.InitializerTypeName);
            if (InitializerType.IsNull())
            {
                //异常处理
            }
            var mapperAssemblyNames = element.MapperAssemblys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var assemblySet = AssemblyFinder.FindAll().ToDictionary(assembly => assembly.GetName().Name);
            foreach (var assemblyName in mapperAssemblyNames)
            {
                if (!assemblySet.ContainsKey(assemblyName))
                {
                    //异常处理
                }
                _mapperAssemblys.Add(assemblySet[assemblyName]);
            }
        }

        /// <summary>
        /// 初始化类型。
        /// </summary>
        public Type InitializerType { get; }

        private readonly List<Assembly> _mapperAssemblys;

        /// <summary>
        /// 映射程序集集合。
        /// </summary>
        public IEnumerable<Assembly> MapperAssemblys
        {
            get
            {
                return _mapperAssemblys;
            }
        }

        /// <summary>
        /// 程序集查找器。
        /// </summary>
        protected IAssemblyFinder AssemblyFinder { get; }
    }
}
