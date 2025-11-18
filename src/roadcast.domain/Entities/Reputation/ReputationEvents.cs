namespace roadcast.domain.Entities.Reputation;

public class ReputationEvents
{
    public Guid Id { get; set; }

    public long FromUser { get; set; }
    
    public long ToUser { get; set; }

    public required string Reason { get; set; }

    public int Delta { get; set; }
}
