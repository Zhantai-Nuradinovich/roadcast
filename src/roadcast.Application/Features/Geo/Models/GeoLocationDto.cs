namespace roadcast.Application.Features.Geo.Models;

public record GeoLocationDto(
    string UserId,
    string? AnonId,
    double Latitude,
    double Longitude,
    double Speed,
    double Heading,
    DateTime Timestamp
);

