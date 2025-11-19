using roadcast.Shared.EventBus;

namespace roadcast.Shared.Contracts;

public interface IEventPublisher
{
    Task PublishAsync(IDomainEvent @event, string topic);
}
