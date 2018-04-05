using System;
using System.Collections.Generic;
using System.Linq;
using NKingime.Core.EF;
using NKingime.Core.Tests.Repository;
using NUnit.Framework;
using NKingime.Core.Tests.Model;
using NKingime.Core.Data;
using NKingime.Core.Utility;
using System.IO;

namespace NKingime.Core.Tests.EF
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class UserRepositoryTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Save()
        {
            var repository = new UserRepository();
            var entity = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "李思思",
                Gender = "M",
                IsHappy = true,
                CreateTime = DateTime.Now,
            };
            repository.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Query()
        {
            var repository = new UserRepository();
            var orderSelector = OrderUtil.Ascending<User>(s => s.Name, s => s.Gender);
            var users = repository.Query(p => p.IsHappy, orderSelector);
        }
    }
}
