using Confluent.Kafka;

namespace roadcast.Infrastructure.Kafka;

public class KafkaProducerFactory
{
    public IProducer<Null, string> CreateProducer(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers
        };

        return new ProducerBuilder<Null, string>(config).Build();
    }
}
