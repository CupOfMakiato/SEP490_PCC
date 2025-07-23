using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class OfflineConsultationRepository : GenericRepository<OfflineConsultation>, IOfflineConsultationRepository
    {
        private readonly AppDbContext _context;

        public OfflineConsultationRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<List<OfflineConsultation?>> GetAllOfflineConsultationByUserIdAsync(Guid userId, string? status)
        {
            return await _context.OfflineConsultation
                .Where(oc =>
                    (oc.ConsultantId == userId || oc.UserId == userId)
                    && !oc.IsDeleted
                    && (status == null || oc.Status == status)
                )
                .ToListAsync();
        }

        public async Task<OfflineConsultation?> GetOfflineConsultationByIdAsync(Guid offlineConsultationId)
        {
            return await _context.OfflineConsultation
                .Where(oc => oc.Id == offlineConsultationId && !oc.IsDeleted)
                .Select(oc => new OfflineConsultation
                {
                    Id = oc.Id,
                    UserId = oc.UserId,
                    ClinicId = oc.ClinicId,
                    ConsultantId = oc.ConsultantId,
                    User = oc.User != null && !oc.User.IsDeleted ? oc.User : null,
                    Clinic = oc.Clinic != null && !oc.Clinic.IsDeleted ? oc.Clinic : null,
                    Consultant = oc.Consultant != null && !oc.Consultant.IsDeleted
                        ? new Consultant
                        {
                            Id = oc.Consultant.Id,
                            UserId = oc.Consultant.UserId,
                            ClinicId = oc.Consultant.ClinicId,
                            User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted ? oc.Consultant.User : null,
                            IsDeleted = oc.Consultant.IsDeleted
                        }
                        : null,
                    IsDeleted = oc.IsDeleted
                })
                .FirstOrDefaultAsync();
        }

        public async Task<OfflineConsultation?> GetOfflineConsultationByOfflineConsultationIdAsync(Guid offlineConsultationId)
        {
            return await _context.OfflineConsultation
                .FirstOrDefaultAsync(oc => oc.Id == offlineConsultationId && !oc.IsDeleted);
        }
    }
}
