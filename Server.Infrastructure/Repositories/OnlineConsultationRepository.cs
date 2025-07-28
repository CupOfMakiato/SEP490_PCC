using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class OnlineConsultationRepository : GenericRepository<OnlineConsultation>, IOnlineConsultationRepository
    {
        private readonly AppDbContext _context;

        public OnlineConsultationRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<UserSubscription?> GetActiveSubscriptionAsync(Guid userId)
        {
            return await _context.UserSubscription
                .Where(us => us.UserId == userId && !us.IsDeleted /* && us.IsActive */)
                .OrderByDescending(us => us.PaymentDate)
                .FirstOrDefaultAsync();
        }

        public async Task<OnlineConsultation?> GetOnlineConsultationByIdAsync(Guid onlineConsultationId)
        {
            return await _context.OnlineConsultation
                .Include(oc => oc.Attachments.Where(a => !a.IsDeleted))
                .Include(oc => oc.User)
                .Include(oc => oc.Consultant)
                .ThenInclude(oc => oc.User)
                .FirstOrDefaultAsync(oc => oc.Id == onlineConsultationId
                                    && !oc.IsDeleted
                                    && oc.User != null && !oc.User.IsDeleted
                                    && oc.Consultant != null && !oc.Consultant.IsDeleted
                                    && oc.Consultant.User != null && !oc.Consultant.User.IsDeleted);
        }

        public async Task<List<OnlineConsultation>> GetOnlineConsultationsByConsultantIdAsync(Guid consultantId)
        {
            return await _context.OnlineConsultation
                .Include(oc => oc.Attachments.Where(a => !a.IsDeleted))
                .Include(oc => oc.User)
                .Include(oc => oc.Consultant)
                .ThenInclude(oc => oc.User)
                .Where(oc => oc.ConsultantId == consultantId
                        && !oc.IsDeleted
                        && oc.User != null && !oc.User.IsDeleted
                        && oc.Consultant != null && !oc.Consultant.IsDeleted
                        && oc.Consultant.User != null && !oc.Consultant.User.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<OnlineConsultation>> GetOnlineConsultationsByUserIdAsync(Guid userId)
        {
            return await _context.OnlineConsultation
                .Include(oc => oc.Attachments.Where(a => !a.IsDeleted))
                .Include(oc => oc.User)
                .Include(oc => oc.Consultant)
                .ThenInclude(oc => oc.User)
                .Where(oc => oc.UserId == userId
                        && !oc.IsDeleted
                        && oc.User != null && !oc.User.IsDeleted
                        && oc.Consultant != null && !oc.Consultant.IsDeleted
                        && oc.Consultant.User != null && !oc.Consultant.User.IsDeleted)
                .ToListAsync();
        }
    }
}
