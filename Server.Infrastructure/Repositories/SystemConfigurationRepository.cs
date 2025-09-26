using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class SystemConfigurationRepository : GenericRepository<SystemConfiguration>, ISystemConfigurationRepository
    {
        public SystemConfigurationRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public async Task<SystemConfiguration> GetSystemConfigurationAsync()
        {
            return await _dbSet.FirstOrDefaultAsync();
        }
    }
}
