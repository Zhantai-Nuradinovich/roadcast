namespace roadcast.Application.Features.Identity.Models;

public record AuthResponseDto(
    string AccessToken, 
    string RefreshToken, 
    string AnonId);
