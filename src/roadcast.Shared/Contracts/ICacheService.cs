namespace roadcast.Shared.Contracts;

public interface ICacheService
{
    Task SetAsync(string key, object value, TimeSpan? expiry = null);
    Task<T?> GetAsync<T>(string key);
}
