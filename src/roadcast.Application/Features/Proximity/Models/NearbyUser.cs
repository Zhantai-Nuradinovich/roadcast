namespace roadcast.Application.Features.Proximity.Models;

public record NearbyUser(
        string AnonId,
        double Latitude,
        double Longitude,
        double DistanceMeters,
        double Heading,
        int Karma,
        string Role // car, pedestrian, bus etc.
    );