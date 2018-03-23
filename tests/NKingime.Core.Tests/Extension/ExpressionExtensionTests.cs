using NKingime.Core.Extension;
using NKingime.Core.Tests.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NKingime.Core.Tests.Extension
{
    /// <summary>
    /// Expression扩展方法测试。
    /// </summary>
    [TestFixture]
    public class ExpressionExtensionTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void And()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id="1",
                    Name="李树生",
                    Gender="F",
                },
                new User
                {
                    Id="2",
                    Name="李思思",
                    Gender="M",
                },
                new User
                {
                     Id="3",
                    Name="王语嫣",
                    Gender="M",
                },
                new User
                {
                     Id="4",
                    Name="赵伟",
                    Gender="F",
                },
            };
            string name = "李";
            Expression<Func<User, bool>> predicate = p => p.Name.Contains(name);
            const string gender = "M";
            //if (!string.IsNullOrWhiteSpace(gender))
            //{
            //    predicate = predicate.And(p => p.Gender == gender);
            //}
            if (!string.IsNullOrWhiteSpace(gender))
            {
                predicate = predicate.Or(p => p.Gender == gender);
            }
            var result = users.Where(predicate.Compile());
        }
    }
}
