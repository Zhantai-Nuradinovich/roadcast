namespace roadcast.Application.Features.Reputation.Models;

public record VoteRequestDto(
    string FromAnonId, 
    string ToAnonId, 
    int Delta, 
    string Reason);
