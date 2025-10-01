using Microsoft.AspNetCore.Http;
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

        public async Task<SystemConfiguration> GetSystemConfigurationAsync()
        {
            return await _unitOfWork.SystemConfigurationRepository.GetSystemConfigurationAsync();
        }
    }
}
