using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.Shared;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using System.Net.Http;

namespace Server.Application.Services
{
    public class SystemConfigurationService : ISystemConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ChangeStatus()
        {
            var systemConfig = await _unitOfWork.SystemConfigurationRepository.GetSystemConfigurationAsync();
            if (systemConfig == null)
            {
                return false;
            }
            systemConfig.IsActive = !systemConfig.IsActive;
            _unitOfWork.SystemConfigurationRepository.Update(systemConfig);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<Result<SystemConfiguration>> CreateSystemConfigurationAsync(SystemConfiguration systemConfiguration)
        {
            await _unitOfWork.SystemConfigurationRepository.Add(systemConfiguration);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<SystemConfiguration>() { Data = systemConfiguration, Error = 0 };

            }
            return new Result<SystemConfiguration>() { Message = "Create fail", Error = 1 };
        }

        public async Task<SystemConfiguration> GetSystemConfigurationAsync()
        {
            return await _unitOfWork.SystemConfigurationRepository.GetSystemConfigurationAsync();
        }

        public async Task<Result<SystemConfiguration>> UpdateSystemConfigurationAsync(SystemConfiguration systemConfiguration)
        {
            _unitOfWork.SystemConfigurationRepository.Update(systemConfiguration);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<SystemConfiguration>() { Data = systemConfiguration, Error = 0 };
            }
            return new Result<SystemConfiguration>() { Message = "Create fail", Error = 1 };
        }
    }
}
