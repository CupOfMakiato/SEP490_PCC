using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class SlotRepository : GenericRepository<Slot>, ISlotRepository
    {
        public SlotRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
        }
    }
}
