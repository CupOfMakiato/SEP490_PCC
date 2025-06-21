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
    public class VitaminRepository : GenericRepository<Vitamin>, IVitaminRepository
    {
        private readonly AppDbContext _context;

        public VitaminRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base (context, currentTime, claimsService)
        {
            _context = context;
        }

        public void DeleteVitamin(Vitamin vitamin)
        {
            _context.Vitamin.Remove(vitamin);
        }

        public async Task<Vitamin> GetVitaminById(Guid vitaminId)
        {
            return await _context.Vitamin.Include(v => v.FoodVitamins)
                                         .Include(v => v.VitaminCategory)
                                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vitamin>> GetVitamins()
        {
            return await _context.Vitamin.Include(v => v.FoodVitamins)
                                         .Include(v => v.VitaminCategory)
                                         .ToListAsync();
        }
    }
}
