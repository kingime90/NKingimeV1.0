using System;
using System.Reflection;
using NKingime.Core.Generic;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 应用程序域程序集查找器。
    /// </summary>
    public class AppDomainAssemblyFinder : FinderBase<Assembly>, IAllAssemblyFinder
    {
        /// <summary>
        /// 查找所有。
        /// </summary>
        /// <returns></returns>
        public override Assembly[] FindAll()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
