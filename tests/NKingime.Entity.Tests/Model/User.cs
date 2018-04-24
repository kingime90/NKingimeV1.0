using System;
using NKingime.Core.Entity;
using NKingime.Entity.Tests.Option;

namespace NKingime.Entity.Tests.Model
{
    public class User : EntityBase, IRecyclable, ILastUpdateTime
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public bool? IsHappy { get; set; }

        public string Mobile { get; set; }

        /// <summary>
        /// 性别类型。
        /// </summary>
        public GenderOption GenderType { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastUpdateTime { get; set; }
    }
}
