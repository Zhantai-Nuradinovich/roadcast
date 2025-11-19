using Microsoft.AspNetCore.SignalR;
using roadcast.Application.Features.Geo.Models;

namespace roadcast.Api.Hubs;

public class GeoHub : Hub
{
    public async Task SendLocation(LocationUpdateDto location)
    {
        await Clients.Others.SendAsync("UserLocationUpdated", new
        {
            location.AnonId,
            location.Latitude,
            location.Longitude,
            location.Speed,
            location.Heading,
            location.Timestamp
        });
    }

    public async Task SubscribeToRegion(string geoHash)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, geoHash);
    }

    public async Task UnsubscribeFromRegion(string geoHash)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, geoHash);
    }
}
