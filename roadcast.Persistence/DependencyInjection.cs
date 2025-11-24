using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using roadcast.Application.Features.Identity.Services;
using roadcast.Infrastructure.Identity;

namespace roadcast.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment environment)
    {
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

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        var identityOptionsConfig = new IdentityOptionsConfig();
        configuration.GetSection(nameof(IdentityOptions)).Bind(identityOptionsConfig);

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = identityOptionsConfig.RequiredLength;
            options.Password.RequireDigit = identityOptionsConfig.RequiredDigit;
            options.Password.RequireLowercase = identityOptionsConfig.RequireLowercase;
            options.Password.RequiredUniqueChars = identityOptionsConfig.RequiredUniqueChars;
            options.Password.RequireUppercase = identityOptionsConfig.RequireUppercase;
            options.Lockout.MaxFailedAccessAttempts = identityOptionsConfig.MaxFailedAttempts;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(identityOptionsConfig.LockoutTimeSpanInDays);
        })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
