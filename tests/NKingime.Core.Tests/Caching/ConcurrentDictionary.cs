using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.Caching
{
    public class ConcurrentDictionaryCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private static readonly ConcurrentDictionary<TKey, TValue> CacheSet;

        static ConcurrentDictionaryCache()
        {
            CacheSet = new ConcurrentDictionary<TKey, TValue>();
        }

        public void Set(TKey key, TValue value)
        {
            CacheSet.AddOrUpdate(key, value, (k, v) =>
            {
                return value;
            });
        }
    }
}
