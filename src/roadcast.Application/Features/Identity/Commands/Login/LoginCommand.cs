//using Mediator;
//using UserService.Application.Features.Authentication.Interfaces;
//using UserService.Application.Shared.Exceptions;

//namespace namespace roadcast.Application.Features.Identity.Commands.Login;

//public record LoginCommand : IRequest<AuthenticationResult>
//{
//    public string Email { get; set; } = string.Empty;
//    public string Password { get; set; } = string.Empty;
//}

//public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResult>
//{
//    private readonly IAuthenticationService _authenticationService;
//    private readonly IJwtTokenService _jwtTokenService;
//    public LoginCommandHandler(IAuthenticationService authenticationService, IJwtTokenService jwtTokenService)
//    {
//        _authenticationService = authenticationService;
//        _jwtTokenService = jwtTokenService;
//    }

//    public async ValueTask<AuthenticationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
//    {
//        var result = await _authenticationService.PasswordSignInAsync(request.Email, request.Password, false);

//        if (!result.Succeeded)
//        {
//            throw new UnauthorizedException("Invalid email and password combination.");
//        }

//        var response = await _jwtTokenService.GenerateClaimsTokenAsync(request.Email, cancellationToken);

//        return new AuthenticationResult
//        {
//            AccessToken = response.AccessToken,
//            TokenType = "Bearer",
//            ExpiresIn = response.ExpiresIn,
//            RefreshToken = response.RefreshToken
//        };
//    }
//}