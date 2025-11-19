namespace roadcast.Application.Features.Reputation.Models;

public record ReputationDelta(
    int Delta,
    string Reason,
    DateTime Timestamp);

