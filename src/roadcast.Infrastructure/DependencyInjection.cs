using Confluent.Kafka;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using roadcast.Application.Features.Geo.Services.Interfaces;
using roadcast.Application.Features.Identity.Services;
using roadcast.Application.Features.Proximity.Services.Interfaces;
using roadcast.Infrastructure.Identity;
using roadcast.Infrastructure.Identity.Options;
using roadcast.Infrastructure.Kafka;
using roadcast.Infrastructure.Redis;
using roadcast.Infrastructure.Repositories;
using roadcast.Shared.Contracts;
using StackExchange.Redis;
using System.Text;

namespace roadcast.Infrastructure;

public static class DependencyInjection
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
        services.AddScoped<IProximityRepository, ProximityRepository>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddTransient<IJwtTokenService, JwtTokenService>();

        var jwtOptions = new JwtOptions();
        configuration.Bind(nameof(JwtOptions), jwtOptions);
        services.AddSingleton(jwtOptions);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
            ValidateIssuer = jwtOptions.ValidateIssuer,
            ValidateAudience = jwtOptions.ValidateAudience,
            ValidAudience = jwtOptions.Audience,
            RequireExpirationTime = jwtOptions.RequireExpirationTime,
            ValidateLifetime = jwtOptions.ValidateLifetime,
            ClockSkew = jwtOptions.Expiration
        };

        services.AddSingleton(tokenValidationParameters);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });

        return services;
    }
}
