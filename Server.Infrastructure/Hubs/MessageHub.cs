using Microsoft.AspNetCore.SignalR;

namespace Server.Infrastructure.Hubs
{
    public class MessageHub : Hub
    {
        public static Dictionary<Guid, string> _ConnectionsMap = new();

        public override async Task OnConnectedAsync()
        {
            var userId = new Guid(Context.GetHttpContext().Request.Query["userId"]);
            _ConnectionsMap[userId] = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = new Guid(Context.GetHttpContext().Request.Query["userId"]);
            _ConnectionsMap.Remove(userId);
            await base.OnDisconnectedAsync(exception);
        }

        // Called by server service to send message
        public async Task SendMessage(Guid userId, string message)
        {
            if (_ConnectionsMap.TryGetValue(userId, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceivedMessage", message);
            }
        }

        public async Task JoinThread(Guid chatThreadId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatThreadId.ToString());
        }

        public async Task LeaveThread(Guid chatThreadId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatThreadId.ToString());
        }
    }
}
