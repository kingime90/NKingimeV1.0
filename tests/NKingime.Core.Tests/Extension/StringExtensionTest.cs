using NKingime.Core.Extension;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.Extension
{
    /// <summary>
    /// 字符串扩展方法单元测试。
    /// </summary>
    [TestFixture]
    public class StringExtensionTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RemoveStart()
        {
            string str = "ABcdefg";
            string result = str.RemoveStart("ABC");
            Assert.IsTrue(result == str);

            result = str.RemoveStart("ABc");
            Assert.IsTrue(result == "defg");

            result = str.RemoveStart("ABC", StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(result == "defg");
        }

        /// <summary>
        /// 移除指定字符串的尾部测试。
        /// </summary>
        [Test]
        public void RemoveEnd()
        {
            string str = "ABcdefgH";
            string result = str.RemoveEnd("fgh");
            Assert.IsTrue(result == str);

            result = str.RemoveEnd("fgH");
            Assert.IsTrue(result == "ABcde");

            result = str.RemoveEnd("fgh", StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(result == "ABcde");
        }
    }
}
