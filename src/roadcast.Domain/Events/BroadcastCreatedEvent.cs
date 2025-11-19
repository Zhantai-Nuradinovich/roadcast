using roadcast.Domain.Entities.Broadcast;

namespace roadcast.Domain.Events;

public record BroadcastCreatedEvent(
    Guid BroadcastId,
    string SenderAnonId,
    BroadcastType Type,
    string Text,
    double Latitude,
    double Longitude,
    int RadiusMeters,
    DateTime CreatedAt,
    string RegionHash
);
