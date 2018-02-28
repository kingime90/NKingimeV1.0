using System;
using NUnit.Framework;

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
            TestEntity testEntity = new TestEntity();
        }
    }
}
