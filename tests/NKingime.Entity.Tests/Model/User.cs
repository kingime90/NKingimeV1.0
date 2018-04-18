using System;
using NKingime.Core.Data;
using NKingime.Entity.Tests.Flag;

namespace NKingime.Entity.Tests.Model
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public bool? IsHappy { get; set; }

        public string Mobile { get; set; }

        /// <summary>
        /// 性别枚举。
        /// </summary>
        public GenderFlag GenderType { get; set; }
    }
}
