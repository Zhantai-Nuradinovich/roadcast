using Microsoft.EntityFrameworkCore;
using roadcast.Domain.Entities.Geo;
using roadcast.Domain.Entities.Identity;

namespace roadcast.Application.Features.Identity.Services;

public interface IApplicationDbContext
{
    DbSet<RefreshToken> RefreshTokens { get; set; }

    DbSet<GeoLocation> GeoLocations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
