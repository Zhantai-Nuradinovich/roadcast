namespace roadcast.Shared.Contracts;

public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}
