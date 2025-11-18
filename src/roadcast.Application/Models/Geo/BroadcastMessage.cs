namespace roadcast.Application.Models.Geo;

public class BroadcastMessage
{
    public required string SenderAnonId { get; set; }
    public string? Type { get; set; }
    public string? Message { get; set; }
    public double Radius { get; set; }
    public DateTime Timestamp { get; set; }
}

