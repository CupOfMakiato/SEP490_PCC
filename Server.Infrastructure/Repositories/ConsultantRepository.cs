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
            return await _context.Consultant.FirstOrDefaultAsync(c => c.Id.Equals(consultantId) && !c.IsDeleted);
        }

        public async Task<List<Consultant>> GetConsultantByNameAsync(string name)
        {
            return await _context.Consultant.Where(c => c.User.UserName.Contains(name) && !c.IsDeleted)
                                        .ToListAsync();
        }

        public async Task<List<Consultant>> GetConsultantsAsync()
        {
            return await _context.Consultant.Where(c => !c.IsDeleted)
                                        .ToListAsync();
        }
    }
}
