using roadcast.Api.Exceptions;

namespace roadcast.Api.Endpoints;

public static class GeoEndpoints
{
    public static void MapGeoEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/geo")
            .WithTags("Geo");

        endpoints
            .MapPost("update", List) // should be web socket
            .WithSummary("Location update");

        endpoints
            .MapGet("nearby?lat={lat}&lng={lng}&radius={radius}&limit={limit}", List)
            .WithSummary("Get nearby users");

        endpoints
            .MapGet("status/{anonId}", List)
            .WithSummary("Get nearby users");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
