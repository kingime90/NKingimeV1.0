using System;
using System.Collections.Generic;
using System.Reflection;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 应用程序域程序集查找。
    /// </summary>
    public class AppDomainAssemblyFinder : AssemblyFinderBase
    {
        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Assembly> FindAll()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
