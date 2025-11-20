namespace roadcast.Shared.Consts;

public static class KafkaTopics
{
    public const string GeoLocationUpdated = "geo.location.updated";
    public const string ProximityNearbyUsersFound = "proximity.nearby-users.found";
    
    public const string UserEnteredProximity = "proximity.user.entered";
    public const string UserExitedProximity = "proximity.user.exited";

    public const string ReputationScoreUpdated = "reputation.score.updated";
    public const string BroadcastMessageSent = "broadcast.message.sent";
}
