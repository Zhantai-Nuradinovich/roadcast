using roadcast.Shared.Common;

namespace roadcast.Domain.Entities.Identity;

public class User : Entity
{
    public string Phone { get; set; }
    public string Nick { get; set; }
    public string AvatarUrl { get; set; }
    public string PrimaryAnonId { get; set; }
    public DateTime RegisteredAt { get; set; }
    public bool IsFleetAccount { get; set; } = false;
}
