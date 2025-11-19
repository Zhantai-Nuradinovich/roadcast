using Confluent.Kafka;
using roadcast.Shared.Contracts;
using roadcast.Shared.EventBus;
using System.Text.Json;

namespace roadcast.Infrastructure.Kafka;

public class KafkaEventPublisher : IEventPublisher
{
    private readonly IProducer<Null, string> _producer;

    public KafkaEventPublisher(IProducer<Null, string> producer)
    {
        _producer = producer;
    }

    public async Task PublishAsync(IDomainEvent @event, string topic)
    {
        var json = JsonSerializer.Serialize(@event);
        await _producer.ProduceAsync(topic, new Message<Null, string> { Value = json });
    }
}
