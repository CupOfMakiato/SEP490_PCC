using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface ISystemConfigurationRepository
    {
        public Task CreateSystemConfigurationAsync(SystemConfiguration systemConfiguration);
        public void UpdateSystemConfiguration(SystemConfiguration systemConfiguration);
        public Task<SystemConfiguration> GetSystemConfigurationAsync();    
    }
}
