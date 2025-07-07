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

        public async Task<AgeGroup> GetGroupByUserDateOfBirthAndTrimester(DateTime dateOfBirth, int trimester)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            return await _dbSet
                .Include(ag => ag.NutrientSuggetions.Where(nt => nt.Trimester == trimester))
                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(ag => ag.FromAge <= age && ag.ToAge >= age);
        }
    }
}
