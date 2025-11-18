namespace roadcast.domain.Entities.Geo;

public class DirectMessage
{
    public Guid Id { get; set; }

    public long SenderId { get; set; }

    public required string TargetVehicleNumber { get; set; }

    public long TargetUserId { get; set; }

    public required string Type { get; set; }

    public required string Text { get; set; }

    public bool Delivered { get; set; }
}
