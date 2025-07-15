using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.Tag;
using Server.Application.DTOs.UserChecklist;
using Server.Application.Interfaces;
using Server.Application.Mappers.CustomChecklistExtensions;
using Server.Application.Repositories;
using Server.Domain.Enums;

namespace Server.Application.Services
{
    public class CustomChecklistService : ICustomChecklistService
    {
        private readonly ICustomChecklistRepository _customChecklistRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public CustomChecklistService(
            ICustomChecklistRepository customChecklistRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsService claimsService)
        {
            _customChecklistRepository = customChecklistRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }
        
        public async Task<Result<List<ViewCustomChecklistDTO>>> ViewAllCustomChecklists()
        {
            var checklists = await _customChecklistRepository.GetAllCustomChecklists();
            var result = _mapper.Map<List<ViewCustomChecklistDTO>>(checklists);
            return new Result<List<ViewCustomChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved custom checklists successfully",
                Data = result
            };
        }
        public async Task<Result<List<ViewCustomChecklistDTO>>> ViewAllActiveCustomChecklists()
        {
            var checklists = await _customChecklistRepository.GetAllActiveCustomChecklists();
            var result = _mapper.Map<List<ViewCustomChecklistDTO>>(checklists);
            return new Result<List<ViewCustomChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved active custom checklists successfully",
                Data = result
            };
        }
        public async Task<Result<List<ViewCustomChecklistDTO>>> ViewAllCompleteChecklist()
        {
            var checklists = await _customChecklistRepository.ViewAllCompletedChecklists();
            var result = _mapper.Map<List<ViewCustomChecklistDTO>>(checklists);
            return new Result<List<ViewCustomChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved completed custom checklists successfully",
                Data = result
            };
        }
        public async Task<Result<List<ViewCustomChecklistDTO>>> ViewAllInCompleteChecklist()
        {
            var checklists = await _customChecklistRepository.ViewAllInCompleteChecklists();
            var result = _mapper.Map<List<ViewCustomChecklistDTO>>(checklists);
            return new Result<List<ViewCustomChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved incomplete custom checklists successfully",
                Data = result
            };
        }
        public async Task<Result<ViewCustomChecklistDTO>> ViewCustomChecklistById(Guid id)
        {
            var customChecklist = await _customChecklistRepository.GetCustomChecklistById(id);
            if (customChecklist == null)
            {
                return new Result<ViewCustomChecklistDTO>
                {
                    Error = 1,
                    Message = "Checklist not found",
                    Data = null
                };
            }

            return new Result<ViewCustomChecklistDTO>
            {
                Error = 0,
                Message = "Checklist retrieved successfully",
                Data = _mapper.Map<ViewCustomChecklistDTO>(customChecklist)
            };
        }
        public async Task<Result<object>> CreateNewCustomChecklist(CreateCustomChecklistDTO CreateCustomChecklistDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }
            var checklist = CreateCustomChecklistDTO.ToCustomChecklist();
            
            checklist.CreatedBy = user;
            checklist.CreationDate = DateTime.UtcNow;

            await _unitOfWork.CustomChecklistRepository.AddAsync(checklist);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new checklist successfully" : "Add new checklist fail",
                Data = CreateCustomChecklistDTO
            };
        }

    }
}
