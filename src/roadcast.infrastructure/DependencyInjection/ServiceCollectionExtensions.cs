using Confluent.Kafka;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Application.Features.Identity.Services;
using roadcast.Infrastructure.Identity;
using roadcast.Infrastructure.Kafka;
using roadcast.Infrastructure.Redis;
using roadcast.Infrastructure.Repositories;
using roadcast.Shared.Contracts;
using StackExchange.Redis;
using System;

namespace roadcast.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration,
        IWebHostEnvironment environment)
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

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        //services.AddHealthChecks()
        //        .AddDbContextCheck<ApplicationDbContext>(name: "Application Database");

        if (environment.IsProduction())
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            .LogTo(Console.WriteLine, LogLevel.Information));
        }

        services.AddScoped<IUserServiceDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());


        return services;
    }
}
