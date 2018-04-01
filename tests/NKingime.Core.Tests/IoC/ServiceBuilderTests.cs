using NKingime.Core.IoC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.IoC
{
    [TestFixture]
    public class ServiceBuilderTests
    {
        [Test]
        public void Build()
        {
            IServiceCollection descriptors = new ServiceCollection();
            IServiceBuilder serviceBuilder = new ServiceBuilder();
            serviceBuilder.Build(descriptors);
        }
    }
}
