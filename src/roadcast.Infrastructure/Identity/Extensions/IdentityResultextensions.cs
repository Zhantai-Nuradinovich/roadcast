using Microsoft.AspNetCore.Identity;
using roadcast.Shared.Common;

namespace roadcast.Infrastructure.Identity.Extensions;

public static class IdentityResultextensions
{
    public static Result MapToResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }

    public static Result MapToResult(this SignInResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(["Invalid login attempt."]);
    }
}
