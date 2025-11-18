namespace roadcast.Domain.Entities;

public class AnonIdentityMap
{
    public long UserId { get; set; }
    
    public string? AnonId { get; set; } // updates at the login: Hash(userId + deviceId + secret + timestamp)

    public DateTime ExpiresAt { get; set; }
}
