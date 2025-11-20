using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Proximity.Models;

namespace roadcast.Application.Features.Proximity.Services.Interfaces;

public interface IProximityService
{
    Task<IEnumerable<NearbyUserDto>> GetNearbyUsersAsync(string userId, double latitude, double longitude, double speed);
    Task ProcessGeoUpdateAsync(LocationUpdateDto geoLocation);
}
