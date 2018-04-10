using System;
using NUnit.Framework;
using NKingime.Core.Initializer;
using NKingime.Core.Config;

namespace NKingime.Core.Tests.Initializer
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class ContextInitializerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Initialize()
        {
            IContextInitializer Initializer = new ContextInitializer();
            Initializer.Initialize(ContextConfig.Instance);
        }
    }
}
