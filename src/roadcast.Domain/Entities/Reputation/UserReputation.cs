using roadcast.Shared.Common;

namespace roadcast.Domain.Entities.Reputation;

public class UserReputation : Entity
{
    public string UserId { get; set; }
    public string AnonId { get; set; }
    public int Score { get; set; }
    public int ThanksCount { get; set; }
    public int ReportsCount { get; set; }
    public bool IsTrusted { get; set; }
    public DateTime UpdatedAt { get; set; }
}
