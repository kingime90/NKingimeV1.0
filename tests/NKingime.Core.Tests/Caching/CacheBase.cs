using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.Caching
{
    public class CacheBase<TKey, TValue>
    {
        private static readonly IDictionary<TKey, TValue> CacheSet;

        static CacheBase()
        {
            CacheSet = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            CacheSet.Add(key, value);
        }

        public TValue Get(TKey key)
        {
            TValue value;
            if (CacheSet.TryGetValue(key, out value))
            {
                return value;
            }
            return default(TValue);
        }
    }
}
