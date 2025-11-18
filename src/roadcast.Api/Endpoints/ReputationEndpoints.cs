using roadcast.Api.Exceptions;

namespace roadcast.Api.Endpoints;

public static class ReputationEndpoints
{
    public static void MapReputationEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/reputation")
            .WithTags("Karma endpoints");

        endpoints
            .MapGet("{anonId}", List)
            .WithSummary("Get user's karma");

        endpoints
            .MapPost("vote", List)
            .WithSummary("Rate karma");

        endpoints
            .MapGet("leaderboard?limit={limit}", List)
            .WithSummary("Top karma in the area");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
