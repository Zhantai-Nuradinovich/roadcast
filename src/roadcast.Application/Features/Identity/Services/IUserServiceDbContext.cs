using Microsoft.EntityFrameworkCore;
using roadcast.Domain.Entities.Identity;

namespace roadcast.Application.Features.Identity.Services;

public interface IUserServiceDbContext
{
    DbSet<RefreshToken> RefreshTokens { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
