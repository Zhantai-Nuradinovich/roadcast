using Microsoft.Extensions.DependencyInjection;

namespace roadcast.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add modules here
        return services;
    }
}
