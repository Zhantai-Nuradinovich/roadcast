using Microsoft.AspNetCore.SignalR;
using roadcast.Application.Features.Broadcast.Models;

namespace roadcast.Api.Hubs;

public class DirectMessageHub : Hub
{
    public async Task SendDirectMessage(string toUserId, string message)
    {
        var fromUserId = Context.UserIdentifier;

        var dto = new DirectMessageDto(
            Guid.NewGuid().ToString(),
            fromUserId!,
            toUserId,
            null,
            null,
            message,
            DateTime.UtcNow
        );

        // send through kafka to consumer to log, save, etc. But this one for testing should be ok
        // await _messageService.SendAsync(dto);

        await Clients.User(toUserId).SendAsync("DirectMessageReceived", dto);
    }
}

