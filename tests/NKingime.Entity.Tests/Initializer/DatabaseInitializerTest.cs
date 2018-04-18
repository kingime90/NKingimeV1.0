using System;
using NUnit.Framework;
using NKingime.Core.Initializer;
using NKingime.Entity.Initializer;
using NKingime.Core.Config;
using System.Linq;

namespace NKingime.Entity.Tests.Initializer
{
    /// <summary>
    /// 数据库初始化单元测试。
    /// </summary>
    [TestFixture]
    public class DatabaseInitializerTest
    {
        /// <summary>
        /// 初始化数据库测试。
        /// </summary>
        [Test]
        public void Initialize()
        {
            IDatabaseInitializer initializer = new DatabaseInitializer();
            initializer.Initialize(ContextConfig.Instance.DbContexts.ToArray());
        }
    }
}
