using Microsoft.Extensions.Logging;
using Server.Application.HangfireInterface;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.HangfireService
{
    public class GrowthDataBGService : IGrowthDataBGService
    {
        private readonly ICurrentTime _currentTime;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GrowthDataBGService> _logger;
        public GrowthDataBGService(
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            ILogger<GrowthDataBGService> logger)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _logger = logger;
        }
        public async Task InactivateExpiredGrowthDataProfiles()
        {
            var now = _currentTime.GetCurrentTime().Date;

            var expiredGrowthDataList = await _unitOfWork.GrowthDataRepository
                .FindAsync(gd => gd.EstimatedDueDate < now.AddDays(-1) && gd.Status == GrowthDataStatus.Active);

            foreach (var growthData in expiredGrowthDataList)
            {
                growthData.Status = GrowthDataStatus.Inactive;
                _unitOfWork.GrowthDataRepository.Update(growthData);
                _logger.LogInformation($"[Hangfire] Marked GrowthData ID: {growthData.Id} as Inactive");
            }

            if (expiredGrowthDataList.Any())
            {
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}
