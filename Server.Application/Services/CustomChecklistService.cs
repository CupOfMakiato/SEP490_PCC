using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.Tag;
using Server.Application.DTOs.UserChecklist;
using Server.Application.Interfaces;
using Server.Application.Mappers.CustomChecklistExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
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
        public async Task<Result<List<ViewCustomChecklistDTO>>> ViewAllArchiveCustomChecklists()
        {
            var checklists = await _customChecklistRepository.GetAllActiveCustomChecklists();
            var result = _mapper.Map<List<ViewCustomChecklistDTO>>(checklists);
            return new Result<List<ViewCustomChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved archived custom checklists successfully",
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
        public async Task<Result<List<ViewCustomChecklistDTO>>> ViewCustomChecklistsByTrimester(int trimester)
        {
            var currentUser = _claimsService.GetCurrentUserId;
            if (currentUser == null || currentUser == Guid.Empty)
            {
                return new Result<List<ViewCustomChecklistDTO>>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var checklists = await _customChecklistRepository.GetCustomChecklistsByTrimester(trimester, currentUser);
            var result = _mapper.Map<List<ViewCustomChecklistDTO>>(checklists);
            return new Result<List<ViewCustomChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved custom checklists by trimester successfully",
                Data = result
            };
        }
        public async Task<Result<object>> CreateNewCustomChecklist(CreateCustomChecklistDTO CreateCustomChecklistDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            if (user == null || user == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
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
                Data = null
            };
        }
        public async Task<Result<object>> EditCustomChecklistInfo(EditCustomChecklistInfoDTO EditCustomChecklistInfoDTO)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }

            var checklist = await _unitOfWork.CustomChecklistRepository.GetByIdAsync(EditCustomChecklistInfoDTO.Id);
            if (checklist == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist not found!",
                    Data = null
                };
            }

            checklist.TaskName = EditCustomChecklistInfoDTO.TaskName ?? checklist.TaskName;
            checklist.Trimester = EditCustomChecklistInfoDTO.Trimester ?? checklist.Trimester;
            checklist.ModificationDate = DateTime.Now;
            checklist.ModificationBy = userId;

            _unitOfWork.CustomChecklistRepository.Update(checklist);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Edit checklist successfully" : "Edit checklist failed",
                Data = EditCustomChecklistInfoDTO
            };
        }
        public async Task<Result<object>> MarkChecklistAsComplete(Guid ChecklistId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var checklist = await _unitOfWork.CustomChecklistRepository.GetByIdAsync(ChecklistId);
            if (checklist == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist not found!",
                    Data = null
                };
            }
            if (checklist.IsCompleted == true)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist is already marked as complete!",
                    Data = null
                };

            }
            else if (checklist.IsCompleted == false)
            {
                checklist.IsCompleted = true;
            }

            checklist.ModificationDate = DateTime.Now;
            checklist.ModificationBy = userId;
            _unitOfWork.CustomChecklistRepository.Update(checklist);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Marked checklist as complete successfully" : "Failed to mark checklist as complete",
                Data = null
            };

        }
        public async Task<Result<object>> MarkChecklistAsInComplete(Guid ChecklistId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var checklist = await _unitOfWork.CustomChecklistRepository.GetByIdAsync(ChecklistId);
            if (checklist == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist not found!",
                    Data = null
                };
            }
            if (checklist.IsCompleted == false)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist is already marked as incomplete!",
                    Data = null
                };
            }
            else if (checklist.IsCompleted == true)
            {
                checklist.IsCompleted = false;
            }

            checklist.ModificationDate = DateTime.Now;
            checklist.ModificationBy = userId;
            _unitOfWork.CustomChecklistRepository.Update(checklist);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Marked checklist as incomplete successfully" : "Failed to mark checklist as incomplete",
                Data = null
            };

        }
        public async Task<Result<object>> ArchiveCustomChecklist(Guid ChecklistId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var checklist = await _unitOfWork.CustomChecklistRepository.GetByIdAsync(ChecklistId);
            if (checklist == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist not found!",
                    Data = null
                };
            }
            if (checklist.IsActive == false)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist is already archived!",
                    Data = null
                };

            }
            else if (checklist.IsActive == true)
            {
                checklist.IsActive = false;
            }

            checklist.ModificationDate = DateTime.Now;
            checklist.ModificationBy = userId;
            _unitOfWork.CustomChecklistRepository.Update(checklist);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Archived checklist successfully" : "Failed to archive checklist",
                Data = null
            };

        }
        public async Task<Result<object>> UnArchiveCustomChecklist(Guid ChecklistId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var checklist = await _unitOfWork.CustomChecklistRepository.GetByIdAsync(ChecklistId);
            if (checklist == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist not found!",
                    Data = null
                };
            }
            if (checklist.IsActive == true)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist is already active!",
                    Data = null
                };

            }
            else if (checklist.IsActive == false)
            {
                checklist.IsActive = true;
            }

            checklist.ModificationDate = DateTime.Now;
            checklist.ModificationBy = userId;
            _unitOfWork.CustomChecklistRepository.Update(checklist);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Unarchived checklist successfully" : "Failed to unarchive checklist",
                Data = null
            };

        }
        public async Task<Result<object>> DeleteCustomChecklist(Guid ChecklistId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var checklist = await _unitOfWork.CustomChecklistRepository.GetByIdAsync(ChecklistId);
            if (checklist == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Checklist not found!",
                    Data = null
                };
            }
            _unitOfWork.CustomChecklistRepository.SoftRemove(checklist);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Delete checklist successfully" : "Failed to delete checklist",
                Data = null
            };
        }
    }
}
