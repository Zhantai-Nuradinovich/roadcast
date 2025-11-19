using roadcast.Shared.Common;

namespace roadcast.Domain.Entities.Geo;

public class GeoLocation : Entity
{
    public string? AnonId { get; set; }
    public required string UserId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Speed { get; set; }
    public double Heading { get; set; }
    public string? GeoHash { get; set; }
    public DateTime Timestamp { get; set; }
}
