using Microsoft.AspNetCore.SignalR;
using roadcast.Application.Features.Broadcast.Models;

namespace roadcast.Api.Hubs;

public class BroadcastHub : Hub
{
    public async Task SendBroadcast(BroadcastPayload payload)
    {
        await Clients.Group(payload.GeoHash)
            .SendAsync("ReceiveBroadcast", payload);
    }

    public async Task SendDirect(string targetAnonId, BroadcastNotificationDto notification)
    {
        await Clients.Group(targetAnonId)
            .SendAsync("ReceiveDirectMessage", notification);
    }

    public async Task SubscribeToGeoHash(string geoHash)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, geoHash);
    }

    public async Task SubscribeToAnon(string anonId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, anonId);
    }
}
