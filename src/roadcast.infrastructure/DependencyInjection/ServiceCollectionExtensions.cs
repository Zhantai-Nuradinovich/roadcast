using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Infrastructure.Kafka;
using roadcast.Infrastructure.Redis;
using roadcast.Infrastructure.Repositories;
using roadcast.Shared.Contracts;

namespace roadcast.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IProducer<Null, string>>(provider =>
        {
            var bootstrapServers = "localhost:9092"; // kafka address
            var producerFactory = new KafkaProducerFactory();
            return producerFactory.CreateProducer(bootstrapServers);
        });

        services.AddScoped<IEventPublisher, KafkaEventPublisher>();
        services.AddScoped<ICacheService, RedisCacheService>();
        services.AddScoped<IGeoRepository, GeoRepository>();
        return services;
    }
}
