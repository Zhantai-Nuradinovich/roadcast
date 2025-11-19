using roadcast.Shared.Common;

namespace roadcast.Domain.Entities.Proximity;

public class ProximityRecord : Entity
{
    public string SubjectAnonId { get; set; }
    public string ObserverAnonId { get; set; }
    public ProximityEventType EventType { get; set; }
    public double DistanceMeters { get; set; }
    public double SubjectSpeed { get; set; }
    public DateTime Timestamp { get; set; }
    public string RegionHash { get; set; }
}

public enum ProximityEventType 
{ 
    Enter, 
    Exit, 
    Passing, 
    Approaching 
}
