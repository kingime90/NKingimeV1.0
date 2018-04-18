using System;
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
            int id = 4;
            var user = userRepository.GetByKey(id);
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// 更新测试。
        /// </summary>
        [Test]
        public void Update()
        {
            int id = 4;
            var user = userRepository.GetByKey(id);
            user.Mobile = "13690000009";
            var result = userRepository.Update(user);
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
            var users = userRepository.QueryAll();
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
