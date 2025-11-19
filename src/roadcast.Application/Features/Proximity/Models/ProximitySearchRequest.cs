namespace roadcast.Application.Features.Proximity.Models;

public record ProximitySearchRequest(
    double Latitude, 
    double Longitude, 
    int RadiusMeters, 
    int Limit = 50);
