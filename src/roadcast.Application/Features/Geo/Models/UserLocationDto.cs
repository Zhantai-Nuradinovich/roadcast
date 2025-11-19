namespace roadcast.Application.Features.Geo.Models;

public record UserLocationDto(
    string AnonId,
    double Latitude,
    double Longitude,
    double DistanceMeters,
    double Heading,
    int Karma
);
