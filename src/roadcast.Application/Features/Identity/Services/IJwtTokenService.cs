using roadcast.Application.Features.Identity.Models;
using System.Security.Claims;

namespace roadcast.Application.Features.Identity.Services;

public interface IJwtTokenService
{
    Task<TokenResult> GenerateClaimsTokenAsync(string email, CancellationToken cancellationToken);
    Task<ClaimsPrincipal?> GetPrincipFromTokenAsync(string token);
    Task<TokenResult> RefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken);
}
