using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<List<Notification>> GetAllNotifications();
        Task<Notification> GetNotificationById(Guid id);

        Task<List<Notification>> GetNotificationsByUserId(Guid userId);
    }
}
