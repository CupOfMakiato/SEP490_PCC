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
    public class NutrientRepository : GenericRepository<Nutrient>, INutrientRepository
    {
        private readonly AppDbContext _context;

        public NutrientRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base (context, currentTime, claimsService)
        {
            _context = context;
        }

        public void DeleteNutrient(Nutrient nutrient)
        {
            _context.Nutrient.Remove(nutrient);
        }

        public async Task<Nutrient> GetNutrientById(Guid nutrientId)
        {
            return await _context.Nutrient.Include(v => v.FoodNutrients)
                                         .Include(v => v.NutrientCategory)
                                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Nutrient>> GetNutrients()
        {
            return await _context.Nutrient.Include(v => v.FoodNutrients)
                                         .Include(v => v.NutrientCategory)
                                         .ToListAsync();
        }
    }
}
