using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace roadcast.Persistence;

public static class DbInitializer
{
    public static IApplicationBuilder UseInitializeDatabase(this IApplicationBuilder application)
    {
        using var serviceScope = application.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        if (dbContext != null && dbContext.Database.GetPendingMigrations().Any())
        {
            Console.WriteLine("Applying  Migrations...");
            dbContext.Database.Migrate();
        }

        // SeedData(dbContext);

        return application;
    }
}
