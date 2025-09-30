using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface ISystemConfigurationService
    {
        public Task<SystemConfiguration> GetSystemConfigurationAsync();
    }
}
