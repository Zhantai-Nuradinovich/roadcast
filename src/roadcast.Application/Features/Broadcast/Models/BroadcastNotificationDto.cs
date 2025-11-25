using roadcast.Domain.Types;

namespace roadcast.Application.Features.Broadcast.Models;

public record BroadcastNotificationDto(
      Guid BroadcastId,
      BroadcastType Type,
      string Icon,
      double DistanceMeters,
      int SenderKarma,
      DateTime CreatedAt
  );