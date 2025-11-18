namespace roadcast.domain.Entities;

public class User
{
    public long Id { get; set; }

    public required string Nickname { get; set; }

    public string? PersonalLink { get; set; }

    public string? VehicleNumber { get; set; }

    public string? VehicleType { get; set; }

    public double LastLat { get; set; }

    public double LastLng { get; set; }
}
