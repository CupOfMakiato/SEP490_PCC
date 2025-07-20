using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
    {
        private readonly AppDbContext _context;

        public ConsultantRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<Consultant> GetConsultantByIdAsync(Guid consultantId)
        {
            return await _context.Consultant.Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id.Equals(consultantId) && !c.IsDeleted);
        }
    }
}
