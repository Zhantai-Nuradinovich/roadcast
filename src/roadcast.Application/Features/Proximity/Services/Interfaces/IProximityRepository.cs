using roadcast.Application.Features.Proximity.Models;

namespace roadcast.Application.Features.Proximity.Services.Interfaces;

public interface IProximityRepository
{
    Task<IEnumerable<NearbyUserDto?>> GetNearbyUsersAsync(string userId, double lat, double lng, double radiusMeters);
}
