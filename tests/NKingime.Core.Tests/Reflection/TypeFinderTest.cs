using NKingime.Core.EF;
using NKingime.Core.Extension;
using NKingime.Core.IoC;
using NKingime.Core.Reflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.IoC
{
    [TestFixture]
    public class TypeFinderTest
    {
        [Test]
        public void IEntityMapperTest()
        {
            ITypeFinder<IEntityMapper> typeFinder = new TypeFinder<IEntityMapper>();
            var entityMapperTypes = typeFinder.Find(p => !p.IsAbstract);
            IEnumerable<IEntityMapper> entityMappers = entityMapperTypes.Select(s => Activator.CreateInstance(s) as IEntityMapper).ToList();
            Type genericType = typeof(EntityMapperBase<,>);
            Type mapperType, baseType;
            var mapperSet = new Dictionary<Type, Type>();
            foreach (var mapper in entityMappers)
            {
                mapperType = mapper.GetType();
                if (genericType.IsGenericAssignableFrom(mapperType, out baseType))
                {
                    mapperSet.Add(baseType.GetGenericArguments().FirstOrDefault(), mapper.DbContextType);
                }
            }
        }
    }
}
