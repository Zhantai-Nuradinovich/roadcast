using roadcast.Shared.Contracts;
using StackExchange.Redis;
using System.Text.Json;

namespace roadcast.Infrastructure.Redis;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _db;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task SetAsync(string key, object value, TimeSpan? expiry = null)
    {
        await _db.StringSetAsync(key, JsonSerializer.Serialize(value), expiry);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var data = await _db.StringGetAsync(key);

        if (data.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(data.ToString());
    }
}
