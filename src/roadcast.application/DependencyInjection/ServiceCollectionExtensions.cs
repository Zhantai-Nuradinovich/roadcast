using Microsoft.Extensions.DependencyInjection;
using roadcast.Infrastructure.DependencyInjection;

namespace roadcast.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();
        return services;
    }
}
