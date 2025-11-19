namespace roadcast.Domain.Events;

public record ReputationChangedEvent(
    string AnonId, 
    int NewScore, 
    string Reason, 
    DateTime Timestamp);
