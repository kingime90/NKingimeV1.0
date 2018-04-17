using NKingime.Core.I18n;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.Internationalization
{
    [TestFixture]
    public class InternationalizationTests
    {
        [Test]
        public void Main()
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            //var myAssem = Assembly.GetExecutingAssembly();
            //var manager = new ResourceManager($"{myAssem.GetName().Name}.I18n.Context-{culture.Name}", myAssem);
            //string String1 = manager.GetString("String1");
            var assembly = typeof(I18nManager).Assembly;
            string cacheKey = I18nManager.GetCacheKey("Context", culture.Name, assembly);
            string string1 = I18nManager.Instance.GetString("String1", cacheKey, assembly);
        }
    }
}
