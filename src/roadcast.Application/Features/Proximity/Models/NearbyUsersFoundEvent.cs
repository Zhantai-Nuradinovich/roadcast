using roadcast.Shared.Contracts;

namespace roadcast.Application.Features.Proximity.Models;

public record NearbyUsersFoundEvent(
    string UserId,
    IEnumerable<NearbyUserDto> NearbyUsers,
    DateTime OccurredAt
) : IDomainEvent;
