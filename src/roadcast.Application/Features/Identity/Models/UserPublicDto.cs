namespace roadcast.Application.Features.Identity.Models;

public record UserPublicDto(
    string AnonIdMask, 
    string Nick, 
    int Karma, 
    IReadOnlyList<string> Badges);
