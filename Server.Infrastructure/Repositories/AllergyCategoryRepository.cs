using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class AllergyCategoryRepository : GenericRepository<AllergyCategory>, IAllergyCategoryRepository
    {
        public AllergyCategoryRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
        {
        }

        public void DeleteAllergyCategory(AllergyCategory allergyCategory)
        {
            _dbSet.Remove(allergyCategory);
        }

        public async Task<AllergyCategory> GetAllergyCategoryById(Guid allergyId)
        {
            return await _dbSet.Include(a => a.Allergies).FirstOrDefaultAsync(a => a.Id == allergyId);
        }

        public async Task<AllergyCategory> GetAllergyCategoryByName(string Name)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Name.Equals(Name));
        }
    }
}
