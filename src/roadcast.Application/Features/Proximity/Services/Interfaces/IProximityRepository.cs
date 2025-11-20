using roadcast.Domain.Entities.Geo;

namespace roadcast.Application.Features.Proximity.Services.Interfaces;

public interface IProximityRepository
{
    Task<IEnumerable<GeoLocation?>> GetNearbyUsersAsync(double lat, double lng, double radiusMeters);
}
