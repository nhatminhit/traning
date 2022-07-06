using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Cache
{
    public static class CacheModel
    {
        private static readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// Get Cache Item
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static int Get(string cacheKey)
        {
            var result = _memoryCache.Get(cacheKey);
            return Convert.ToInt32(result);
        }


        /// <summary>
        /// Add Item To Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        public static void Add(string cacheKey, int value)
        {

            //setting up cache options
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };

            //setting cache entries
            _memoryCache.Set(cacheKey, value, cacheExpiryOptions);

        }

        /// <summary>
        /// Delete from Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        public static void Delete(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);

        }
    }
}