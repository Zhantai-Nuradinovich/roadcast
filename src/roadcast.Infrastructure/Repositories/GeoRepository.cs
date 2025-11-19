using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Domain.Entities.Geo;
using StackExchange.Redis;
using System.Text.Json;

namespace roadcast.Infrastructure.Repositories;

public class GeoRepository : IGeoRepository
{
    private readonly IConnectionMultiplexer _redis;
    private readonly string _geoIndex = "geo:index";
    private readonly string _geoHashKey = "geo:locations";

    public GeoRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task<GeoLocation?> GetAsync(string userId)
    {
        var db = _redis.GetDatabase();
        var cached = await db.HashGetAsync(_geoHashKey, userId);

        return cached.HasValue
            ? JsonSerializer.Deserialize<GeoLocation>(cached.ToString())
            : null;
    }

    public async Task UpsertAsync(GeoLocation location)
    {
        var db = _redis.GetDatabase();

        await db.HashSetAsync(_geoHashKey, location.UserId, JsonSerializer.Serialize(location));

        await db.GeoAddAsync(_geoIndex,
            new GeoEntry(location.Longitude, location.Latitude, location.UserId));
    }

    public async Task<IEnumerable<GeoLocation?>> GetNearbyUsersAsync(double lat, double lng, double radiusMeters)
    {
        var db = _redis.GetDatabase();

        var results = await db.GeoRadiusAsync(
            _geoIndex,
            lng,
            lat,
            radiusMeters,
            GeoUnit.Meters);

        if (results == null || results.Length == 0) return [];

        var nearbyIds = results.Select(x => x.Member.ToString()).ToArray();

        var hashValues = await db.HashGetAsync(_geoHashKey, nearbyIds.Select(x => (RedisValue)x).ToArray());

        return hashValues
            .Where(h => h.HasValue)
            .Select(h => JsonSerializer.Deserialize<GeoLocation>(h.ToString()));
    }
}