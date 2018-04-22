using System;
using NKingime.Core.Entity;
using NKingime.Entity.Tests.Flag;

namespace NKingime.Entity.Tests.Model
{
    public class User : EntityBase, IRecyclable, ILastUpdateTime
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public bool? IsHappy { get; set; }

        public string Mobile { get; set; }

        /// <summary>
        /// 性别枚举。
        /// </summary>
        public GenderFlag GenderType { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastUpdateTime { get; set; }
    }
}
