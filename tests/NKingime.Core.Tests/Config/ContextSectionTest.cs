//using NKingime.Core.EF;
//using NKingime.Core.Extension;
//using NKingime.Core.IoC;
//using NKingime.Core.Reflection;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Configuration;
//using NKingime.Core.Config;

//namespace NKingime.Core.Tests.IoC
//{
//    [TestFixture]
//    public class ContextSectionTest
//    {
//        [Test]
//        public void GetContextSectionTest()
//        {
//            const string SectionName = "custom.config/context";
//            var contextSection = (ContextSection)ConfigurationManager.GetSection(SectionName);
//            var dbContexts = contextSection.DbContexts.OfType<DbContextElement>().Select(s => new DbContextConfig(s)).ToList();
//        }

//        [Test]
//        public void TestContextConfig()
//        {
//            var contextConfig = ContextConfig.Instance;

//        }
//    }
//}
