using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using roadcast.Api.Hubs;
using roadcast.Application.Features.Proximity.Models;

namespace roadcast.Api.Kafka;

public class NearbyUsersFoundConsumer : IConsumer<NearbyUsersFoundEvent>
{

    public NearbyUsersFoundConsumer(IHubContext<ProximityHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(NearbyUsersFoundEvent message)
    {
        await _hubContext
            .Clients
            .User(message.UserId)
            .SendAsync("NearbyUsersUpdated", message.NearbyUsers);
    }
}
