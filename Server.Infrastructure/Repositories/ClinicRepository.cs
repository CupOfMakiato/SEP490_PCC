using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        private readonly AppDbContext _context;

        public ClinicRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<Clinic> GetClinicByIdAsync(Guid clinicId)
        {
            return await _context.Clinic.Include(c => c.Consultants)
                                        .FirstOrDefaultAsync(c => c.Id.Equals(clinicId) && !c.IsDeleted);
        }

        public async Task<List<Clinic>> GetClinicByNameAsync(string name)
        {
            return await _context.Clinic.Where(c => c.Name.Contains(name) && !c.IsDeleted)
                                        .ToListAsync();
        }

        public async Task<List<Clinic>> GetClinicsAsync()
        {
            return await _context.Clinic.Where(c => !c.IsDeleted)
                                        .ToListAsync();
        }
    }
}
