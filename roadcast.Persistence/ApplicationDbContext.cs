using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using roadcast.Application.Features.Identity.Services;
using roadcast.Domain.Entities.Geo;
using roadcast.Domain.Entities.Identity;
using roadcast.Infrastructure.Identity;
using roadcast.Shared.Common;
using roadcast.Shared.Contracts;

namespace roadcast.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly ICurrentUserService? _currentUserService;

    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<GeoLocation> GeoLocations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService)
        : base(options)
    {
        _currentUserService = currentUserService;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService?.UserId ?? string.Empty;
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService?.UserId ?? string.Empty;
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
