using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class DiseaseRepository : GenericRepository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base (context, currentTime, claimsService)
        {
        }

        public void DeleteDisease(Disease disease)
        {
            _dbSet.Remove(disease);
        }

        public async Task<Disease> GetDiseaseById(Guid diseaseId)
        {
            return await _dbSet.Include(d => d.DiseaseGrowthData)
                               .Include(d => d.FoodDisease)
                               .FirstOrDefaultAsync(d => d.Equals(diseaseId));
        }

        public async Task<IEnumerable<Disease>> GetDiseases()
        {
            return await _dbSet.Include(d => d.DiseaseGrowthData)
                               .Include(d => d.FoodDisease)
                               .ToListAsync();
        }
    }
}
