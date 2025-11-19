namespace roadcast.Application.Features.Proximity.Models;

public record ProximitySearchResponse(IReadOnlyList<NearbyUser> Users);
