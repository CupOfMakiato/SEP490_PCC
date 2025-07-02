using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Blog;
using Server.Application.Interfaces;
using Server.Application.Repositories;
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

        public BasicBioMetricService(IUnitOfWork unitOfWork, IMapper mapper, IBasicBioMetricRepository basicBioMetricRepository, 
            IClaimsService claimsService)
        {
            _basicBioMetricRepository = basicBioMetricRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
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
    }
}
