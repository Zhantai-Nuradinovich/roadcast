using Microsoft.AspNetCore.SignalR;
using roadcast.Domain.Events;

namespace roadcast.Api.Hubs;

public class ProximityHub : Hub
{
    public async Task NotifyProximity(ProximityEvent proximityEvent)
    {
        await Clients.Group(proximityEvent.ObserverAnonId)
            .SendAsync("OnProximityEvent", proximityEvent);
    }

    public async Task SubscribeToUser(string anonId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, anonId);
    }

    public async Task UnsubscribeFromUser(string anonId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, anonId);
    }
}
