using roadcast.Application.Features.Geo.Models;

namespace roadcast.Application.Features.Geo.Services.Interfaces;

public interface IGeoService
{
    Task UpdateLocationAsync(GeoLocationDto location);
    Task<IEnumerable<GeoLocationDto>> GetNearbyUsersAsync(string userId, double radiusMeters);
}
