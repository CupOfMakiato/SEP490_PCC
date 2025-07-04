using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.ClinicWorkRule;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class ClinicWorkRuleService : IClinicWorkRuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClinicWorkRuleRepository _clinicWorkRuleRepository;

        public ClinicWorkRuleService(IUnitOfWork unitOfWork, IMapper mapper, IClinicWorkRuleRepository clinicWorkRuleRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clinicWorkRuleRepository = clinicWorkRuleRepository;
        }

        public async Task<Result<ViewClinicWorkRuleDTO>> CreateClinicWorkRule(AddClinicWorkRuleDTO clinicWorkRule)
        {
            var clinicWorkRuleMapper = _mapper.Map<ClinicWorkRule>(clinicWorkRule);

            clinicWorkRuleMapper.Id = Guid.NewGuid();

            if (clinicWorkRule.DailySchedules != null && clinicWorkRule.DailySchedules.Any())
            {
                clinicWorkRuleMapper.DailySchedules = clinicWorkRule.DailySchedules.Select(d => new DailySchedule
                {
                    Id = Guid.NewGuid(),
                    ClinicWorkRuleId = clinicWorkRuleMapper.Id,
                    Day = d.Day,
                    StartTime = d.StartTime,
                    EndTime = d.EndTime,
                    IsWorking = d.IsWorking,
                    Note = d.Note
                }).ToList();
            }

            await _clinicWorkRuleRepository.AddAsync(clinicWorkRuleMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewClinicWorkRuleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new clinic work rule successfully" : "Add new clinic work rule failed",
                Data = _mapper.Map<ViewClinicWorkRuleDTO>(clinicWorkRuleMapper)
            };
        }

        public async Task<Result<ViewClinicWorkRuleDTO>> GetClinicWorkRuleAsync(Guid clinicId)
        {
            var clinicWorkRuleMapper = _mapper.Map<ViewClinicWorkRuleDTO>(
                _clinicWorkRuleRepository.GetClinicWorkRuleAsync(clinicId).Result
            );

            var (daysOff, totalWorkingDays) = await _clinicWorkRuleRepository.CalDaysOffAndTotalWorkingDaysAsync(clinicId);

            clinicWorkRuleMapper.DaysOff = daysOff;
            clinicWorkRuleMapper.TotalWorkingDays = totalWorkingDays;

            return new Result<ViewClinicWorkRuleDTO>
            {
                Error = 0,
                Message = "View clinic work rule successfully",
                Data = clinicWorkRuleMapper
            };
        }

        public async Task<Result<bool>> SoftDeleteSclinicWorkRule(Guid clinicId)
        {
            var clinicWorkRule = await _clinicWorkRuleRepository.GetClinicWorkRuleAsync(clinicId);

            if (clinicWorkRule == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Clinic work rule not found",
                    Data = false
                };
            }

            _clinicWorkRuleRepository.SoftRemove(clinicWorkRule);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Soft delete clinic work rule successfully" : "Soft delete clinic work rule failed",
                Data = result > 0
            };
        }

        public async Task<Result<ViewClinicWorkRuleDTO>> UpdateClinicWorkRule(UpdateClinicWorkRuleDTO clinicWorkRule)
        {
            var clinicWorkRuleObj = await _clinicWorkRuleRepository.GetClinicWorkRuleAsync(clinicWorkRule.ClinicId);

            if (clinicWorkRuleObj == null)
            {
                return new Result<ViewClinicWorkRuleDTO>
                {
                    Error = 1,
                    Message = "Clinic work rule not found",
                    Data = null
                };
            }

            _mapper.Map(clinicWorkRule, clinicWorkRuleObj);

            _clinicWorkRuleRepository.Update(clinicWorkRuleObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewClinicWorkRuleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update clinic work rule successfully" : "Update clinic work rule failed",
                Data = _mapper.Map<ViewClinicWorkRuleDTO>(clinicWorkRuleObj)
            };
        }
    }
}
