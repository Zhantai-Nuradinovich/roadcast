using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Proximity.Models;
using roadcast.Application.Features.Proximity.Services.Interfaces;
using roadcast.Shared.Consts;
using roadcast.Shared.Contracts;
using roadcast.Shared.Helpers;

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

    public async Task ProcessGeoUpdateAsync(LocationUpdateDto geoLocation)
    {
        var radius = SpeedToRadiusHelper.GetRadiusBySpeed(geoLocation.Speed);

        var nearbyUsers = await _repository.GetNearbyUsersAsync(
            geoLocation.UserId,
            geoLocation.Latitude,
            geoLocation.Longitude,
            radius
        );

        if (nearbyUsers == null)
        {
            return;
        }

        var evt = new NearbyUsersFoundEvent(
            geoLocation.UserId,
            nearbyUsers!,
            geoLocation.Timestamp
        );

        await _eventPublisher.PublishAsync(evt, KafkaTopics.ProximityNearbyUsersFound);
    }
}
