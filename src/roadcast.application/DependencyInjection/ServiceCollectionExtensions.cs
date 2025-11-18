using Microsoft.Extensions.DependencyInjection;
using roadcast.infrastructure.DependencyInjection;

namespace roadcast.application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();
        return services;
    }
}
