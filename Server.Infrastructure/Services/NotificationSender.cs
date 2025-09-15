using Microsoft.AspNetCore.SignalR;
using Server.Application.Interfaces;
using Server.Infrastructure.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Services
{
    public class NotificationSender : INotificationSender
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationSender(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationToServer(Guid userId, object payload, string type)
        {
            if (NotificationHub._ConnectionsMap.TryGetValue(userId, out var connectionId))
            {
                await _hubContext.Clients.Client(connectionId)
                    .SendAsync("ReceivedNotification", new
                    {
                        type = type,
                        payload = payload
                    });
            }
        }
        //public async Task SendPingToServer(Guid userId)
        //{
        //    if (NotificationHub._ConnectionsMap.TryGetValue(userId, out var connectionId))
        //    {
        //        await _hubContext.Clients.Client(connectionId)
        //            .SendAsync("Ping");
        //    }
        //}
    }
}
