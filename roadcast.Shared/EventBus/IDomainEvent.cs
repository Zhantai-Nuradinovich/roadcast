namespace roadcast.Shared.EventBus;

public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}
