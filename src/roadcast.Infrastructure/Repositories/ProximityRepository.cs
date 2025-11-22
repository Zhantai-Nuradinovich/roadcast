using roadcast.Application.Features.Proximity.Models;
using roadcast.Application.Features.Proximity.Services.Interfaces;
using roadcast.Domain.Entities.Geo;
using StackExchange.Redis;
using System.Text.Json;

namespace roadcast.Infrastructure.Repositories;

public class ProximityRepository : IProximityRepository
{
    private readonly IConnectionMultiplexer _redis;
    private readonly string _proximityIndex = "geo:index";
    private readonly string _proximityHashKey = "geo:locations";

    public ProximityRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task<IEnumerable<NearbyUserDto?>> GetNearbyUsersAsync(string userId, double lat, double lng, double radiusMeters)
    {
        var db = _redis.GetDatabase();

        var results = await db.GeoRadiusAsync(
            _proximityIndex,
            lng,
            lat,
            radiusMeters,
            GeoUnit.Meters,
            count: 50,
            order: Order.Ascending,
            options: GeoRadiusOptions.WithDistance);

        if (results == null || results.Length == 0) return [];

        var ids = results.Select(x => x.Member.ToString()).ToArray();
        var hashValues = await db.HashGetAsync(_proximityHashKey, ids.Select(x => (RedisValue)x).ToArray());

        return results.Zip(hashValues, (geo, hash) =>
        {
            if (!hash.HasValue) return null;

            var location = JsonSerializer.Deserialize<GeoLocation>(hash.ToString());
            return new NearbyUserDto(
                UserId: location.UserId,
                AnonId: location.AnonId,
                Latitude: location.Latitude,
                Longitude: location.Longitude,
                DistanceMeters: geo.Distance ?? 0,
                Speed: location.Speed,
                Heading: location.Heading,
                KarmaScore: 100, // place holder before adding profile updates
                Role: "unknown"
            );
        })
        .Where(x => x != null && x.UserId != userId)!;
    }
}