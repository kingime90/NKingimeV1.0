//using System;
//using System.Collections.Generic;
//using System.Linq;
//using NKingime.Core.EF;
//using NKingime.Core.Tests.Repository;
//using NUnit.Framework;
//using NKingime.Core.Tests.Model;
//using NKingime.Core.Data;
//using NKingime.Core.Utility;
//using System.IO;
//using NKingime.Core.Initializer;
//using NKingime.Core.Config;

//namespace NKingime.Core.Tests.EF
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [TestFixture]
//    public class UserRepositoryTests
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        [Test]
//        public void Save()
//        {
//            var repository = new UserRepository();
//            var entity = new User
//            {
//                Id = Guid.NewGuid().ToString(),
//                Name = "李思思",
//                Gender = "M",
//                IsHappy = true,
//                CreateTime = DateTime.Now,
//            };
//            repository.Save(entity);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        [Test]
//        public void Query()
//        {
//            IContextInitializer Initializer = new ContextInitializer();
//            Initializer.Initialize(ContextConfig.Instance);
//            var repository = new UserRepository();
//            var orderSelector = OrderUtil.Ascending<User>(s => s.Name, s => s.Gender);
//            var users = repository.PagedList(20, 1, p => p.IsHappy, orderSelector);
//        }
//    }
//}
