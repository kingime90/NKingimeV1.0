using System;
using NUnit.Framework;
using NKingime.Core.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NKingime.Core.Tests.Data
{
    /// <summary>
    /// 测试实体单元测试。
    /// </summary>
    [TestFixture]
    public class TestEntityTests
    {
        /// <summary>
        /// 实例化对象。
        /// </summary>
        [Test]
        public void New()
        {
            //TestEntity testEntity = new TestEntity();
            //OrderSelector<TestEntity> orderSelector = new OrderSelector<TestEntity>();
            //orderSelector.KeySelectors.Add(s => s.Id);
            //orderSelector.KeySelectors.Add(s => s.CreateTime);

            //Expression<Func<TestEntity, bool>> sdsd = null;
            //TestEntity testEntity1 = new TestEntity();
            //TestEntity testEntity2 = new TestEntity();
            //Save(testEntity1);
            ////Save(testEntity1, testEntity2);
            //var list = new List<TestEntity>();
            //list.Add(testEntity1);
            //list.Add(testEntity2);
            //Save(list);
            //var list2 = list.ToArray();
            //Save(list2);
            //Expression<Func<TestEntity, bool>> expression = (Expression<Func<TestEntity, bool>>)null;
        }

        public int Save(TestEntity entity)
        {
            return 0;
        }
        //public int Save(params TestEntity[] entitys)
        //{
        //    return 0;
        //}

        public int Save(IEnumerable<TestEntity> entitys)
        {
            return 0;
        }
    }
}
