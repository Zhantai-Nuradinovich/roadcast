namespace roadcast.Application.Models.Geo;

public class NearbyContact
{
    public required string AnonId { get; set; }
    public double Distance { get; set; }
    public string? Direction { get; set; }
    public double Heading { get; set; }
}
