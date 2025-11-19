using Microsoft.AspNetCore.SignalR;
using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Geo.Services.Interfaces;

namespace roadcast.Api.Hubs;

public class GeoHub : Hub
{
    private readonly IGeoService _geoService;

    public GeoHub(IGeoService geoService)
    {
        _geoService = geoService;
    }

    public async Task SendLocation(LocationUpdateDto location)
    {
        var geoHash = await _geoService.UpdateLocationAsync(location)!;
        
        if (location.GeoHash != null)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, location.GeoHash!);
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, geoHash!);

        await Clients.GroupExcept(geoHash, Context.ConnectionId)
            .SendAsync("UserLocationUpdated", new
            {
                location.AnonId,
                location.Latitude,
                location.Longitude,
                location.Speed,
                location.Heading,
                location.Timestamp
            });
    }
}
