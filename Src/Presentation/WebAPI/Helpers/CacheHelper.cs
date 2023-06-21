using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace WebAPI.Helpers
{
    public static class CacheHelper
    {

        public static async Task<string?> GetStringAsyncHelper(this IDistributedCache cache, string keyName)
        {
            return await cache.GetStringAsync(keyName);
        }
        public static async Task SetStringAsyncHelper(this IDistributedCache cache, string keyName, string keyValue)
        {
            await cache.SetStringAsync(keyName, keyValue);
        }

        public static async Task RemoveStringAsyncHelper(this IDistributedCache cache, string keyName)
        {
            await cache.RemoveAsync(keyName);
        }



        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache,
                                                    string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
                                                 string recordId,
                                                 T data,
                                                 TimeSpan? absoluteExpireTime = null,
                                                 TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(30);
            options.SlidingExpiration = slidingExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

    }
}
