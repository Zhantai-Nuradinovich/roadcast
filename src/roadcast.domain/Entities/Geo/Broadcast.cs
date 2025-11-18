namespace roadcast.Domain.Entities.Geo;

public class Broadcast
{
    public Guid Id { get; set; }

    public long SenderId { get; set; }

    public required string Type { get; set; }

    public string? Text { get; set; }

    public double Lat { get; set; }

    public double Lng { get; set; }

    public int Radius { get; set; }
}
