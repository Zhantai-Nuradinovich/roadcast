using roadcast.Domain.Entities.Broadcast;

namespace roadcast.Application.Features.Broadcast.Models;

public record BroadcastPayload(
     Guid BroadcastId,
     BroadcastType Type,
     string Icon,
     string Text,
     string VoiceUrl,
     string GeoHash,
     DateTime CreatedAt,
     int SenderKarma
 );
