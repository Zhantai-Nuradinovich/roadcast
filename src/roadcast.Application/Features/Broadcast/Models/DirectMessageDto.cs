namespace roadcast.Application.Features.Broadcast.Models;

public record DirectMessageDto(
    string MessageId,
    string FromUserId,
    string ToUserId,
    string? FromAnonId,
    string? ToAnonId,
    string MessageText,
    DateTime SentAt
);
