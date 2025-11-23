using roadcast.Shared.Contracts;

namespace roadcast.Application.Features.Broadcast.Models;

public record DirectMessageSentEvent(
    string MessageId,
    string FromUserId,
    string ToUserId,
    string MessageText,
    DateTime OccurredAt
) : IDomainEvent;
