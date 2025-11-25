using roadcast.Domain.Types;

namespace roadcast.Application.Features.Broadcast.Models;

public record BroadcastRequestDto(
    string AnonId,
    BroadcastType Type,
    string Text,
    string VoiceUrl,
    double Latitude,
    double Longitude,
    int RadiusMeters
);
