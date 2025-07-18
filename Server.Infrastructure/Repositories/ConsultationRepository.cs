using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ConsultationRepository : GenericRepository<Consultation>, IConsultationRepository
    {
        private readonly AppDbContext _context;

        public ConsultationRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<List<Consultation>> GetConsultationByConsultantIdAsync(Guid consultantId)
        {
            return await _context.Consultation
                .Where(c => c.ConsultantId == consultantId && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Consultation> GetConsultationByIdAsync(Guid consultationId)
        {
            return await _context.Consultation
                .Include(c => c.Clinic)
                .Include(c => c.Consultant)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == consultationId && !c.IsDeleted);
        }

        public Task<Consultation> GetConsultationByUserIdAsync(Guid userId)
        {
            return _context.Consultation
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);
        }
    }
}
