namespace roadcast.Application.Features.Geo.Models;

public record LocationUpdateDto(
    string UserId,
    string AnonId,
    double Latitude,
    double Longitude,
    double Speed,
    double Heading,
    DateTime Timestamp,
    string? GeoHash
);

