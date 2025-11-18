using roadcast.api.Exceptions;

namespace roadcast.api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder.MapGroup("api/products")
            .WithOpenApi();

        endpoints.MapGet(string.Empty, List).WithSummary("Product list");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
