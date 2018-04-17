using NKingime.Core.Data;
using System;

namespace NKingime.Core.Tests.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : GuidIdentity, ICreateTime
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsHappy { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
