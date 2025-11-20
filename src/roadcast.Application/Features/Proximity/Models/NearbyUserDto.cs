namespace roadcast.Application.Features.Proximity.Models;

public record NearbyUserDto(
    string UserId,
    string? AnonId,
    double Latitude,
    double Longitude,
    double DistanceMeters,
    double Speed,
    double Heading,
    int KarmaScore,
    string Role // car, pedestrian, bus etc.
);

