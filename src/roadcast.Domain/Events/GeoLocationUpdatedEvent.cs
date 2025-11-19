using roadcast.Shared.EventBus;

namespace roadcast.Domain.Events;

public record GeoLocationUpdatedEvent(
    string AnonId,
    double Latitude,
    double Longitude,
    double Speed,
    double Heading,
    DateTime OccurredAt,
    string? GeoHash
) : IDomainEvent;
