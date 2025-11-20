using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Proximity.Models;
using roadcast.Application.Features.Proximity.Services.Interfaces;
using roadcast.Shared.Contracts;

namespace roadcast.Application.Features.Proximity.Services;

public class ProximityService : IProximityService 
{
    private readonly IProximityRepository _repository;
    private readonly IEventPublisher _eventPublisher;

    public ProximityService(IProximityRepository repository, IEventPublisher eventPublisher)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
    }
    public async Task<IEnumerable<NearbyUserDto>> GetNearbyUsersAsync(string userId, double latitude, double longitude, double speed)
    {
        if (string.IsNullOrEmpty(userId)) 
            throw new ArgumentNullException(nameof(userId));

        return (await _repository.GetNearbyUsersAsync(latitude, longitude, speed)) // GET RAIDUS BY SPEED
            .Select(x => new NearbyUserDto(
                userId,
                x.AnonId,
                x.Latitude,
                x.Longitude,
                x.DistanceMeters,
                x.Speed,
                x.Heading,
                x.KarmaScore,
                x.Role
            ));
    }

    public Task ProcessGeoUpdateAsync(LocationUpdateDto geoLocation)
    {
        throw new NotImplementedException();
    }
}
