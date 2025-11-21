using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using roadcast.Api.Hubs;
using roadcast.Application.Features.Proximity.Models;
using roadcast.Shared.Consts;
using System.Text.Json;

namespace roadcast.Api.Kafka.Consumers;

public class NearbyUsersFoundConsumerService : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer;
    private readonly IHubContext<ProximityHub> _hubContext;

    public NearbyUsersFoundConsumerService(IHubContext<ProximityHub> hubContext)
    {
        var config = new ConsumerConfig
        {
            GroupId = KafkaTopics.ProximityGroup,
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Null, string>(config)
            .Build();

        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe(KafkaTopics.ProximityNearbyUsersFound);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);

                var message = consumeResult.Message.Value;

                var nearbyEvent = JsonSerializer.Deserialize<NearbyUsersFoundEvent>(message);
                if (nearbyEvent is null)
                    continue;

                await _hubContext
                    .Clients
                    .User(nearbyEvent.UserId)
                    .SendAsync("NearbyUsersUpdated", nearbyEvent.NearbyUsers);
            }
            catch (ConsumeException ex)
            {
                // log or something
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
