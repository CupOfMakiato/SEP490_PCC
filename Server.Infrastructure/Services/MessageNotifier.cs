using Microsoft.AspNetCore.SignalR;
using Server.Application.Interfaces;
using Server.Infrastructure.Hubs;

namespace Server.Infrastructure.Services
{
    public class MessageNotifier : IMessageNotifier
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageNotifier(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyMessageSentAsync(Guid chatThreadId, object message)
        {
            await _hubContext.Clients.Group(chatThreadId.ToString())
                .SendAsync("ReceiveMessage", message);
        }
    }
}
