using roadcast.Api.Exceptions;

namespace roadcast.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/products")
            .WithTags("Products");

        endpoints.MapGet(string.Empty, List).WithSummary("Product list");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
