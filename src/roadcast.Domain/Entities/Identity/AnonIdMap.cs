namespace roadcast.Domain.Entities.Identity;

public class AnonIdMap
{
    public string AnonId { get; set; }
    public Guid UserId { get; set; }
    public DateTime LinkedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}
