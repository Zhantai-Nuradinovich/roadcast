using Microsoft.AspNetCore.SignalR;
using roadcast.Application.Features.Reputation.Models;

namespace roadcast.Api.Hubs;

public class ReputationHub : Hub
{
    public async Task SendReputationUpdate(ReputationDto reputation)
    {
        await Clients.Group(reputation.AnonId)
            .SendAsync("OnReputationUpdated", reputation);
    }

    public async Task Vote(VoteRequestDto vote)
    {
        await Clients.Group(vote.ToAnonId)
            .SendAsync("OnVoteReceived", vote);
    }

    public async Task SubscribeToReputation(string anonId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, anonId);
    }
}
