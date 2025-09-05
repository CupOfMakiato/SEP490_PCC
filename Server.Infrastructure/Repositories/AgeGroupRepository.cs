using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class AgeGroupRepository : GenericRepository<AgeGroup>, IAgeGroupRepository
    {
        public AgeGroupRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }

        public void Delete(AgeGroup ageGroup)
        {
            _dbSet.Remove(ageGroup);
        }

        public async Task<AgeGroup> GetAgeGroupById(Guid id)
        {
            return await _dbSet.Include(ag => ag.EnergySuggestions).Include(ag => ag.NutrientSuggetions).FirstOrDefaultAsync(ag => ag.Id == id);
        }

        public async Task<AgeGroup> GetAgeGroupByUserDateOfBirth(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(ag => ag.FromAge <= age && ag.ToAge >= age);
        }

        public async Task<AgeGroup> GetAgeGroupFrom20To29()
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(ag => ag.FromAge <= 29 && ag.ToAge >= 20);
        }
    }
}
