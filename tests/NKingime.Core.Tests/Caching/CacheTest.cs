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
//using NKingime.Core.Tests.Caching;
//using System.Collections.Concurrent;

//namespace NKingime.Core.Tests.IoC
//{
//    [TestFixture]
//    public class CacheTest
//    {
//        [Test]
//        public void Main()
//        {
//            var cacheACache = new CacheACache();
//            var cacheBCache = new CacheBCache();
//            cacheACache.Add("Cache", new CacheA() { Name = "CacheA", Remark = "CacheA" });
//            cacheBCache.Add("Cache", new CacheB() { Name = "CacheB", Describe = "CacheB" });

//            var cacheACache2 = new CacheACache();
//            var cacheBCache2 = new CacheBCache();

//            IDictionary<string, string> set = new ConcurrentDictionary<string, string>();
//            set.Add("AA", "AA");
//            var type = set.GetType();
//            IDictionary<string, string>  set2 = new Dictionary<string, string>();
//            var type2 = set2.GetType();
//            set2.Add("BB", "BB");
//        }
//    }
//}

