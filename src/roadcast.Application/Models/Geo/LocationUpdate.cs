namespace roadcast.Application.Models.Geo;

public class LocationUpdate
{
    public required string AnonId { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public double Speed { get; set; }
    public double Heading { get; set; }
    public DateTime Timestamp { get; set; }
}

