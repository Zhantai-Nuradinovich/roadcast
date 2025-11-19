using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Infrastructure.Kafka;
using roadcast.Infrastructure.Redis;
using roadcast.Infrastructure.Repositories;
using roadcast.Shared.Contracts;
using StackExchange.Redis;

namespace roadcast.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(provider =>
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["Redis:BootstrapServers"],
            };
            return new ProducerBuilder<Null, string>(config).Build();
        });
        services.AddScoped<IEventPublisher, KafkaEventPublisher>();

        var redis = ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]!);
        services.AddSingleton<IConnectionMultiplexer>(redis);

        services.AddScoped<ICacheService, RedisCacheService>();
        services.AddScoped<IGeoRepository, GeoRepository>();

        return services;
    }
}
