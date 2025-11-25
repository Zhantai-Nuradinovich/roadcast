using roadcast.Domain.Types;

namespace roadcast.Domain.Events;

public record ProximityEvent(
    Guid EventId,
    ProximityEventType EventType,
    string SubjectAnonId,
    string ObserverAnonId,
    double DistanceMeters,
    double SubjectSpeed,
    double Latitude,
    double Longitude,
    DateTime Timestamp
);
