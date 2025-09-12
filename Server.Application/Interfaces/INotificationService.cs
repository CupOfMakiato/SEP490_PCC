using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllNotifications();
        Task<Notification> GetNotificationById(Guid id);
        Task<Notification> CreateNotification(Notification notification, object payload = null, string type = "Generic");
        Task<List<Notification>> GetNotificationsByUserId(Guid userId);
        Task<Notification> MarkNotificationAsRead(Guid id);
        Task<Notification> UpdateNotification(Notification notification);
        Task<bool> DeleteNotification(Guid id);
    }
}
