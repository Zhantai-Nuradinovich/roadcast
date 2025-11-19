using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Domain.Entities.Geo;
using roadcast.Domain.Events;
using roadcast.Shared.Consts;
using roadcast.Shared.Contracts;
using roadcast.Shared.Helpers;

namespace roadcast.Application.Features.Geo.Services;

public class GeoService : IGeoService
{
    private readonly IGeoRepository _repository;
    private readonly IEventPublisher _eventPublisher;

    public GeoService(IGeoRepository repository, IEventPublisher eventPublisher)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
    }

    public async Task<string> UpdateLocationAsync(LocationUpdateDto dto)
    {
        var geoHash = GeoHashHelper.Encode(dto.Latitude, dto.Longitude);
        
        var geoLocation = new GeoLocation
        {
            UserId = dto.UserId,
            AnonId = dto.AnonId,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Speed = dto.Speed,
            Heading = dto.Heading,
            Timestamp = DateTime.UtcNow,
            GeoHash = geoHash
        };

        await _repository.UpsertAsync(geoLocation);

        await _eventPublisher.PublishAsync(
            new GeoLocationUpdatedEvent(
                geoLocation.UserId,
                geoLocation.Latitude,
                geoLocation.Longitude,
                geoLocation.Speed,
                geoLocation.Heading,
                geoLocation.Timestamp,
                geoLocation.GeoHash),
            KafkaTopics.GeoLocationUpdated);

        return geoHash;
    }

    public async Task<IEnumerable<GeoLocationDto>> GetNearbyUsersAsync(string userId, double radiusMeters)
    {
        if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException(nameof(userId));
        var current = await _repository.GetAsync(userId);
        if (current == null) return Enumerable.Empty<GeoLocationDto>();

        return (await _repository.GetNearbyUsersAsync(current.Latitude, current.Longitude, radiusMeters))
            .Select(x => new GeoLocationDto(
                userId,
                x.AnonId,
                x.Latitude,
                x.Longitude,
                x.Speed,
                x.Heading,
                x.Timestamp,
                x.GeoHash
            ));
    }
}
