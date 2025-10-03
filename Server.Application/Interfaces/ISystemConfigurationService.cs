using Server.Application.Abstractions.Shared;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface ISystemConfigurationService
    {
        public Task<SystemConfiguration> GetSystemConfigurationAsync();
        public Task<Result<SystemConfiguration>> UpdateSystemConfigurationAsync(SystemConfiguration systemConfiguration);
        public Task<Result<SystemConfiguration>> CreateSystemConfigurationAsync(SystemConfiguration systemConfiguration);
        public Task<bool> ChangeStatus();
    }
}
