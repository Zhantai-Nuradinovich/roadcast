using MediatR;
using roadcast.Application.Features.Identity.Models;
using roadcast.Application.Features.Identity.Services;

namespace roadcast.Application.Features.Identity.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<AuthenticationResult>
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationResult>
{
    private readonly IJwtTokenService _jwtTokenService;

    public RefreshTokenCommandHandler(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthenticationResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _jwtTokenService.RefreshTokenAsync(request.AccessToken, request.RefreshToken, cancellationToken);

        if (!result.Succeeded)
        {
            throw new Exception(result.Error);
        }

        return new AuthenticationResult
        {
            AccessToken = result.AccessToken,
            TokenType = "Bearer",
            ExpiresIn = result.ExpiresIn,
            RefreshToken = result.RefreshToken
        };
    }
}
