using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface ISystemConfigurationRepository : IGenericRepository<SystemConfiguration>
    {
        public Task<SystemConfiguration> GetSystemConfigurationAsync();    
    }
}
