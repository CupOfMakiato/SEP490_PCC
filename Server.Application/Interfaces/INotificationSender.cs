using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface INotificationSender
    {
        Task SendNotificationToServer(Guid userId, object payload, string message);
        //Task SendPingToServer(Guid userId);
    }
}
