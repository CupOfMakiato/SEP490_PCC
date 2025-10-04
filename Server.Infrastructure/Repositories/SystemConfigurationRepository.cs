using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class SystemConfigurationRepository : ISystemConfigurationRepository
    {
        private readonly AppDbContext _context;

        public SystemConfigurationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateSystemConfigurationAsync(SystemConfiguration systemConfiguration)
        {
           await _context.SystemConfigurations.AddAsync(systemConfiguration);
        }

        public async Task<SystemConfiguration> GetSystemConfigurationAsync()
        {
            return await _context.SystemConfigurations.FirstOrDefaultAsync();
        }

        public void UpdateSystemConfiguration(SystemConfiguration systemConfiguration)
        {
            _context.SystemConfigurations.Update(systemConfiguration);
        }
    }
}
