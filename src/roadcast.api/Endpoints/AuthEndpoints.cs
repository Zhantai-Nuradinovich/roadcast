using MediatR;
using roadcast.Api.Exceptions;
using roadcast.Api.Requests;
using roadcast.Application.Features.Identity.Commands.Login;
using roadcast.Application.Features.Identity.Commands.RefreshToken;
using roadcast.Application.Features.Identity.Commands.RegisterUser;

namespace roadcast.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoints = builder
            .MapGroup("api/auth")
            .WithTags("Auth");


        endpoints.MapPost("login", async (LoginRequest request, IMediator mediator) =>
        {
            var command = new LoginCommand()
            {
                Email = request.Email.Trim(),
                Password = request.Password.Trim()
            };

            var result = await mediator.Send(command);
            return Results.Ok(result);
        })
            .WithName("Login")
            .Produces(StatusCodes.Status200OK);

        endpoints.MapPost("api/refresh", async (RefreshTokenRequest request, IMediator mediator) =>
        {
            var command = new RefreshTokenCommand()
            {
                AccessToken = request.AccessToken.Trim(),
                RefreshToken = request.RefreshToken.Trim()
            };

            var result = await mediator.Send(command);
            return Results.Ok(result);
        })
        .WithName("Refresh")
        .Produces(StatusCodes.Status200OK);

        endpoints.MapPost("register", async (RegisterRequest request, IMediator mediator) =>
        {
            var command = new RegisterUserCommand
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim(),
                Password = request.Password.Trim()
            };

            await mediator.Send(command);
            return Results.Ok();
        })
        .WithName("Register")
        .Produces(StatusCodes.Status200OK);


        endpoints
            .MapPost("logout", List)
            .WithSummary("Logout from the system!");

        endpoints
            .MapGet("me", List)
            .WithSummary("Logout from the system!");
    }

    public static async Task<List<string>> List()
    {
        throw new ServiceErrorException("testteststsetsetste");
    }
}
