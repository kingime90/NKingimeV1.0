using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.Caching
{
    public class DictionaryCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private static readonly Dictionary<TKey, TValue> CacheSet;

        static DictionaryCache()
        {
            CacheSet = new Dictionary<TKey, TValue>();
        }

        public void Set(TKey key, TValue value)
        {
            if (CacheSet.ContainsKey(key))
            {
                CacheSet[key] = value;
            }
            else
            {
                CacheSet.Add(key, value);
            }
        }
    }
}
