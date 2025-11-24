using MediatR;
using roadcast.Application.Features.Identity.Models;
using roadcast.Application.Features.Identity.Services;

namespace roadcast.Application.Features.Identity.Commands.RegisterUser;

public record RegisterUserCommand : IRequest<Unit>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly IAuthenticationService _authenticationService;

    public RegisterUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        var result = await _authenticationService.RegisterUserAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception("failed to register user.");
        }

        return Unit.Value;
    }
}
