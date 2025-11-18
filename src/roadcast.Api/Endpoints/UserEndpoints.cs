using roadcast.Api.Exceptions;

namespace roadcast.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/user")
            .WithTags("User");

        endpoints
            .MapGet("{anonId}", List)
            // optional auth
            .WithSummary("Get public user info: anon ID, nick, badge, karma!");

        endpoints
            .MapPut("me", List)
            .WithSummary("Update public user info!");

        endpoints
            .MapPost("me/device", List)
            .WithSummary("Register device!");

        endpoints
            .MapDelete("me/device/{deviceId}", List)
            .WithSummary("Logout from the system!");

        endpoints
            .MapPost("me/opt-in", List)
            .WithSummary("Enable/refresh geolocation!");

        endpoints
            .MapPost("me/verify", List)
            .WithSummary("Attach phone or something idk!");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
