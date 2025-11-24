using Confluent.Kafka;
using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Proximity.Services.Interfaces;
using roadcast.Shared.Consts;
using System.Text.Json;

namespace roadcast.Api.Kafka.Consumers;

public class GeoLocationUpdatedConsumerService : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer;
    private readonly IServiceScopeFactory _scopeFactory;

    public GeoLocationUpdatedConsumerService(IServiceScopeFactory scopeFactory)
    {
        var config = new ConsumerConfig
        {
            GroupId = "geo-location-updated-consumers",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Null, string>(config).Build();
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe(KafkaTopics.GeoLocationUpdated);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);

                var message = consumeResult.Message.Value;

                var @event = JsonSerializer.Deserialize<GeoLocationUpdatedEvent>(message);
                if (@event is null)
                    continue;

                using var scope = _scopeFactory.CreateScope();
                
                var proximityService = scope.ServiceProvider.GetRequiredService<IProximityService>();
                
                await proximityService.ProcessGeoUpdateAsync(@event.locationUpdate);
            }
            catch (ConsumeException ex)
            {
                // лог ошибки, но не падаем
            }
        }
    }

    public override void Dispose()
    {
        _consumer.Close();
        _consumer.Dispose();
        base.Dispose();
    }
}