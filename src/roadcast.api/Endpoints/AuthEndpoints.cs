using roadcast.api.Exceptions;

namespace roadcast.api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder.MapGroup("api/auth")
            .WithOpenApi();

        endpoints.MapGet(string.Empty, List).WithSummary("Product list");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
