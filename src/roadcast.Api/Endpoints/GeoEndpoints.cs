using roadcast.Api.Exceptions;
using roadcast.Application.Features.Geo.Models;
using roadcast.Application.Features.Geo.Services.Interfaces;

namespace roadcast.Api.Endpoints;

public static class GeoEndpoints
{
    public static void MapGeoEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/geo")
            .WithTags("Geo");

        endpoints
            .MapPost("update", async (LocationUpdateDto dto, IGeoService geoService) =>
            {
                await geoService.UpdateLocationAsync(dto);
                return Results.Ok();
            })
            .WithSummary("Update user location");

        endpoints
            .MapGet("nearby?radius={radius}", async (int radius, IGeoService geoService) =>
            {
                // get authenticated user id
                await geoService.GetNearbyUsersAsync("USERID", radius);
                return Results.Ok();
            })
            .WithSummary("Get nearby users");

        //endpoints
        //    .MapGet("status/{anonId}", List)
        //    .WithSummary("Get nearby users");
    }
}
