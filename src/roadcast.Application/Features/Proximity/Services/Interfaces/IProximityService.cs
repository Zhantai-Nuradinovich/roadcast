using roadcast.Application.Features.Geo.Models;

namespace roadcast.Application.Features.Proximity.Services.Interfaces;

public interface IProximityService
{
    Task ProcessGeoUpdateAsync(LocationUpdateDto geoLocation);
}
