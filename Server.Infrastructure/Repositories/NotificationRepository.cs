using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly AppDbContext _dbContext;

        public NotificationRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Notification>> GetAllNotifications()
        {
            return await _dbContext.Notification
                .Include(n => n.NotificationCreatedByUser)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<Notification> GetNotificationById(Guid id)
        {
            return await _dbContext.Notification
                .Include(n => n.NotificationCreatedByUser)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<Notification>> GetNotificationsByUserId(Guid userId)
        {
            return await _dbContext.Notification
                .Include(n => n.NotificationCreatedByUser)
                .Where(c => !c.IsDeleted && c.CreatedBy == userId)
                .ToListAsync();
        }
    }
}
