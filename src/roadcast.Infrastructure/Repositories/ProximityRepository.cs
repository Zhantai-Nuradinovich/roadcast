using roadcast.Application.Features.Proximity.Services.Interfaces;
using roadcast.Domain.Entities.Geo;
using StackExchange.Redis;
using System.Text.Json;

namespace roadcast.Infrastructure.Repositories;

public class ProximityRepository : IProximityRepository
{
    private readonly IConnectionMultiplexer _redis;
    private readonly string _proximityIndex = "proximity:index";
    private readonly string _proximityHashKey = "proximity:locations";

    public ProximityRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }
    // Geo location to Nearby User - check logic
    public async Task<IEnumerable<GeoLocation?>> GetNearbyUsersAsync(double lat, double lng, double radiusMeters)
    {
        var db = _redis.GetDatabase();

        var results = await db.GeoRadiusAsync(
            _proximityIndex,
            lng,
            lat,
            radiusMeters,
            GeoUnit.Meters);

        if (results == null || results.Length == 0) return [];

        var nearbyIds = results.Select(x => x.Member.ToString()).ToArray();

        var hashValues = await db.HashGetAsync(_proximityHashKey, nearbyIds.Select(x => (RedisValue)x).ToArray());

        return hashValues
            .Where(h => h.HasValue)
            .Select(h => JsonSerializer.Deserialize<GeoLocation>(h.ToString()));
    }
}