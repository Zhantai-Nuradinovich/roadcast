using roadcast.Shared.EventBus;

namespace roadcast.Application.Features.Geo.Models;

public record GeoLocationUpdatedEvent(
    LocationUpdateDto locationUpdate,
    DateTime OccurredAt
) : IDomainEvent;
