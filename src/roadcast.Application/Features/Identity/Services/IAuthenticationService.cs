using roadcast.Application.Features.Identity.Models;
using roadcast.Shared.Common;
using System.Security.Claims;

namespace roadcast.Application.Features.Identity.Services;

public interface IAuthenticationService
{
    Task AddClaimToUser(string email, string claimName, string claimValue);
    Task AddUserToRoleAsync(string email, string roleName);
    Task CreateRoleAsync(string roleName);
    Task<List<AppUser>> GetAllUsersAsync();
    Task<AppUser> GetUserInfoAsync(string userId);
    Task<IEnumerable<string?>> GetRolesAsync();
    Task<IList<Claim>> GetUserClaimsAsync(string email);
    Task<IList<string>> GetUserRolesAsync(string email);
    Task<Result> PasswordSignInAsync(string email, string password, bool LockoutOnFailure);
    Task<Result> RegisterUserAsync(AppUser user, string password);
    Task RemoveUserFromRoleAsync(string email, string roleName);
}
