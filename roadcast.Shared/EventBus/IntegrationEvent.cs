namespace roadcast.Shared.EventBus;

public record IntegrationEvent(
    string EventName,
    string PayloadJson,
    DateTime OccurredAt = default)
{
    public IntegrationEvent() : this(null, null, DateTime.UtcNow) { }
}
