using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class NSAttributeRepository : GenericRepository<NSAttribute>, INSAttributeRepository
    {
        public NSAttributeRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }
    }
}
