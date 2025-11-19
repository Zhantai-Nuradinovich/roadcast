using roadcast.Shared.Common;

namespace roadcast.Domain.Entities.Broadcast;

public class BroadcastMessage : Entity
{
    public string SenderAnonId { get; set; }
    public string SenderUserId { get; set; }
    public BroadcastType Type { get; set; }
    public string Text { get; set; }
    public string VoiceUrl { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int RadiusMeters { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public int EstimatedRecipients { get; set; }
    public int DeliveredCount { get; set; }
    public int ReportCount { get; set; }
    public string RegionHash { get; set; }
}

public enum BroadcastType 
{ 
    SOS, 
    ThankYou, 
    Yield, 
    Accident, 
    PickupRequest, 
    ChatInvite 
}
