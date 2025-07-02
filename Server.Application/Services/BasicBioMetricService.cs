using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.Interfaces;
using Server.Application.Mappers.BasicBioMetricExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class BasicBioMetricService : IBasicBioMetricService
    {
        private readonly IBasicBioMetricRepository _basicBioMetricRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly ICurrentTime _currentTime;

        public BasicBioMetricService(IUnitOfWork unitOfWork, IMapper mapper, IBasicBioMetricRepository basicBioMetricRepository,
            IClaimsService claimsService, ICurrentTime currentTime)
        {
            _basicBioMetricRepository = basicBioMetricRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
            _currentTime = currentTime;
        }
        public async Task<Result<List<ViewBasicBioMetricDTO>>> ViewAllBasicBioMetrics()
        {
            var BBMs = await _unitOfWork.BasicBioMetricRepository.GetAllBasicBioMetrics();

            var result = _mapper.Map<List<ViewBasicBioMetricDTO>>(BBMs);

            return new Result<List<ViewBasicBioMetricDTO>>
            {
                Error = 0,
                Message = "View all BBMs successfully",
                Data = result
            };
        }
        public async Task<Result<ViewBasicBioMetricDTO>> ViewBasicBioMetricById(Guid bbmId)
        {
            var BBM = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(bbmId);

            // Check if blog exists
            if (BBM == null)
            {
                return new Result<ViewBasicBioMetricDTO>
                {
                    Error = 1,
                    Message = "BBM not found",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewBasicBioMetricDTO>(BBM);

            return new Result<ViewBasicBioMetricDTO>
            {
                Error = 0,
                Message = "View BBM successfully",
                Data = result
            };
        }
        public async Task<Result<object>> CreateBasicBioMetric(CreateBasicBioMetricDTO CreateBasicBioMetricDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            var today = _currentTime.GetCurrentTime().Date;

            var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(CreateBasicBioMetricDTO.GrowthDataId);
            if (growthData == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Growth data not found.",
                    Data = null
                };
            }
            if (growthData.BasicBioMetric != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Basic biometric already exists for this growth data.",
                    Data = null
                };
            }
            var bbm = CreateBasicBioMetricDTO.ToBBM();
            bbm.CreatedBy = user;
            bbm.CreationDate = today;

            await _unitOfWork.BasicBioMetricRepository.AddAsync(bbm);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0
                    ? "BBM created successfully."
                    : "Failed to create BBM.",
                Data = null
            };
        }
        public async Task<Result<object>> EditBasicBioMetric(EditBasicBioMetricDTO EditBasicBioMetricDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            var today = _currentTime.GetCurrentTime().Date;
            var exsitingbbm = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(EditBasicBioMetricDTO.Id);
            if (exsitingbbm == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "BBM not found.",
                    Data = null
                };
            }

            exsitingbbm.WeightKg = EditBasicBioMetricDTO.WeightKg ?? exsitingbbm.WeightKg;
            exsitingbbm.HeightCm = EditBasicBioMetricDTO.HeightCm ?? exsitingbbm.HeightCm;
            exsitingbbm.SystolicBP = EditBasicBioMetricDTO.SystolicBP;
            exsitingbbm.DiastolicBP = EditBasicBioMetricDTO.DiastolicBP;
            exsitingbbm.HeartRateBPM = EditBasicBioMetricDTO.HeartRateBPM;
            exsitingbbm.BloodSugarLevelMgDl = EditBasicBioMetricDTO.BloodSugarLevelMgDl;
            exsitingbbm.Notes = EditBasicBioMetricDTO.Notes;
            exsitingbbm.ModificationBy = user;
            exsitingbbm.ModificationDate = today;

            _unitOfWork.BasicBioMetricRepository.Update(exsitingbbm);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "BBM updated successfully." : "Failed to update BBM.",
                Data = null
            };
        }
        public async Task<Result<object>> DeleteBasicBioMetric(Guid bbmId)
        {
            var bbm = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(bbmId);
            if (bbm == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "BBM not found.",
                    Data = null
                };
            }

            _unitOfWork.BasicBioMetricRepository.SoftRemove(bbm);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "BBM deleted successfully." : "Failed to delete BBM.",
                Data = null
            };
        }
    }
}
