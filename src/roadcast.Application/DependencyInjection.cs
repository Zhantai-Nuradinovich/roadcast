using Microsoft.Extensions.DependencyInjection;
using roadcast.Application.Features.Geo.Services;
using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Application.Features.Proximity.Services;
using roadcast.Application.Features.Proximity.Services.Interfaces;
using System.Reflection;

namespace roadcast.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IGeoService, GeoService>();
        services.AddScoped<IProximityService, ProximityService>();
        // Add modules here
        return services;
    }
}
