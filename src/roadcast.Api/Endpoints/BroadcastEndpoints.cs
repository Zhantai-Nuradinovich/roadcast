using roadcast.Api.Exceptions;

namespace roadcast.Api.Endpoints;

public static class BroadcastEndpoints
{
    public static void MapBroadcastEndpoints(this IEndpointRouteBuilder builder)
    {
        //var endpoints = builder
        //    .MapGroup("api/broadcasts")
        //    .WithTags("Broadcasting messages");

        //endpoints
        //    .MapPost(string.Empty, List)
        //    .WithSummary("Broadcast a message");

        //endpoints
        //    .MapGet("{id}", List)
        //    .WithSummary("Read broadcast message");

        //endpoints
        //    .MapGet("recent?lat={lat}&lng={lng}&radius={radius}&since={since}", List)
        //    .WithSummary("Get recent broadcasts");

        //endpoints
        //    .MapPost("{id}/react", List)
        //    .WithSummary("React to a broadcast message");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
