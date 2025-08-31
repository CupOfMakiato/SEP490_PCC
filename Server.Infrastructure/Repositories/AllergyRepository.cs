using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class AllergyRepository : GenericRepository<Allergy>, IAllergyRepository
    {
        public AllergyRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public void DeleteAllergy(Allergy allergy)
        {
            _dbSet.Remove(allergy);
        }

        public async Task<List<Allergy>> GetAllAllergies()
        {
            return await _dbSet
                .Include(a => a.AllergyCategory)
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<Allergy> GetAllergyById(Guid allergyId)
        {
            return await _dbSet
            .Include(a => a.AllergyCategory)
            .Include(a => a.UserAllergy)
            .Include(a => a.FoodAllergy)
            .FirstOrDefaultAsync(a => a.Id == allergyId && !a.IsDeleted);
        }
    }
}
