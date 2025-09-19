using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Notification;
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
        Task<Result<ViewNotificationDTO>> GetNotificationById(Guid id);
        Task<Notification> CreateNotification(Notification notification, object payload = null, string type = "Generic");
        Task<Result<List<ViewNotificationDTO>>> GetNotificationsByUserId(Guid userId);
        Task<Result<ViewNotificationDTO>> MarkNotificationAsRead(Guid id);
        Task<Notification> UpdateNotification(Notification notification);
        Task<bool> DeleteNotification(Guid id);
    }
}
