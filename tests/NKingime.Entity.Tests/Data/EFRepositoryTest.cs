using System;
using System.Linq;
using NUnit.Framework;
using NKingime.Entity.Tests.Initializer;
using NKingime.Entity.Tests.Model;
using NKingime.Entity.Data;
using NKingime.Core.Data;
using NKingime.Core.Utility;

namespace NKingime.Entity.Tests.Data
{
    /// <summary>
    /// EntityFramework数据仓储测试。
    /// </summary>
    [TestFixture]
    public class EFRepositoryTest
    {
        private static IRepository<User> userRepository;

        /// <summary>
        /// 初始化。
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            new DatabaseInitializerTest().Initialize();
            userRepository = new EFRepository<User>();
        }

        /// <summary>
        /// 保存测试。
        /// </summary>
        [Test]
        public void Save()
        {
            var user = new User
            {
                Name = "张萌萌",
                IsHappy = true,
                Gender = "F",
                Mobile = "13600998887",
            };
            var result = userRepository.Save(user);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 根据主键获取数据实体测试。
        /// </summary>
        [Test]
        public void GetByKey()
        {
            var sds= string.Equals(null, "", StringComparison.OrdinalIgnoreCase);
            int id = 1;
            var user = userRepository.GetByKey(id);
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// 更新测试。
        /// </summary>
        [Test]
        public void Update()
        {
            int id = 1;
            var user = userRepository.GetByKey(id);
            user.Mobile = "13690000008";
            var result = userRepository.Update(user);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 更新未跟踪的数据。
        /// </summary>
        [Test]
        public void UpdateNoTracking()
        {
            var users = userRepository.Query();
            var firstUser = users.FirstOrDefault();
            firstUser.Mobile = "13509098765";
            var result = userRepository.Update(firstUser);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 根据主键逻辑删除数据实体测试。
        /// </summary>
        [Test]
        public void RecycleByKey()
        {
            int id = 1;
            var result = userRepository.RecycleByKey(id);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 根据主键逻辑还原数据实体测试。
        /// </summary>
        [Test]
        public void RestoreByKey()
        {
            int id = 1;
            var result = userRepository.RestoreByKey(id);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 根据主键删除数据实体测试。
        /// </summary>
        [Test]
        public void DeleteByKey()
        {
            int id = 2;
            var result = userRepository.DeleteByKey(id);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 删除测试。
        /// </summary>
        [Test]
        public void Delete()
        {
            int id = 4;
            var user = userRepository.GetByKey(id);
            var result = userRepository.Delete(user);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 获取第一个或默认的数据实体测试。
        /// </summary>
        [Test]
        public void FirstOrDefault()
        {
            var user = userRepository.FirstOrDefault();
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// 查询所有数据实体列表测试。
        /// </summary>
        [Test]
        public void QueryAll()
        {
            var users = userRepository.Query();
            Assert.IsTrue(users != null && users.Count > 0);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表测试。
        /// </summary>
        [Test]
        public void Query()
        {
            var users = userRepository.Query(p => p.IsHappy.HasValue && p.IsHappy.Value);
            Assert.IsTrue(users != null && users.Count > 0);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表测试。
        /// </summary>
        [Test]
        public void QueryAndOrderBy()
        {
            var nameAscending = OrderUtil.Ascending<User>(s => s.Name);
            //值类型排序，需要转换
            var createTimeDescending = OrderUtil.Descending<User>(s => new { s.CreateTime });
            var users = userRepository.Query(p => p.IsHappy.HasValue && p.IsHappy.Value, nameAscending, createTimeDescending);
            Assert.IsTrue(users != null && users.Count > 0);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表测试。
        /// </summary>
        [Test]
        public void PagedList()
        {
            //值类型排序，需要转换
            var createTimeDescending = OrderUtil.Descending<User>(s => new { s.CreateTime });
            int pageSize, pageIndex;
            pageSize = 20;
            pageIndex = 1;
            var pagedResult = userRepository.PagedList(pageSize, pageIndex, p => p.IsHappy.HasValue && p.IsHappy.Value, createTimeDescending);
            Assert.IsTrue(pagedResult != null && !pagedResult.IsEmpty);
        }
    }
}
