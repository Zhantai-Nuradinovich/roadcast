using roadcast.Shared.Contracts;

namespace roadcast.Application.Features.Geo.Models;

public record GeoLocationUpdatedEvent(
    LocationUpdateDto locationUpdate,
    DateTime OccurredAt
) : IDomainEvent;
