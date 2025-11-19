namespace roadcast.Application.Features.Reputation.Models;

public record ReputationDto(
    string AnonId,
    int Score,
    bool IsTrusted,
    IReadOnlyList<string> Badges);
