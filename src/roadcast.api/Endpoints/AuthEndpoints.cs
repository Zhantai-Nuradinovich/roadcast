using roadcast.Api.Exceptions;

namespace roadcast.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/auth")
            .WithTags("Auth");

        endpoints
            .MapPost("register", List)
            .WithSummary("Register in the system!");

        endpoints
            .MapPost("login", List)
            .WithSummary("Login in the system!");

        endpoints
            .MapPost("refresh", List)
            .WithSummary("Refresh token!");

        endpoints
            .MapPost("logout", List)
            .WithSummary("Logout from the system!");

        endpoints
            .MapGet("me", List)
            .WithSummary("Logout from the system!");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
