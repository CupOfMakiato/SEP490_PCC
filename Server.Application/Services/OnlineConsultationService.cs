using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OnlineConsultation;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class OnlineConsultationService : IOnlineConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOnlineConsultationRepository _onlineConsultationRepository;

        public OnlineConsultationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOnlineConsultationRepository onlineConsultationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _onlineConsultationRepository = onlineConsultationRepository;
        }

        public async Task<Result<ViewOnlineConsultationDTO>> BookOnlineConsultationAsync(AddOnlineConsultationDTO onlineConsultation)
        {
            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(onlineConsultation.UserId);

            if (user == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = null
                };
            }

                var schedule = await _unitOfWork.ScheduleRepository
                .GetScheduleByIdAsync(onlineConsultation.ScheduleId);

            if (schedule == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any schedule, please try again!",
                    Data = null
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(schedule.ConsultantId);

            if (consultant == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var subscription = await _onlineConsultationRepository
                .GetActiveSubscriptionAsync(onlineConsultation.UserId);

            if (subscription == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "User must have an active subscription to book a consultation.",
                    Data = null
                };
            }

            var availableSchedule = await _unitOfWork.ScheduleRepository
                .GetScheduleAvailableByIdAsync(onlineConsultation.ScheduleId);

            if (availableSchedule == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Schedule is not available or does not exist.",
                    Data = null
                };
            }

            var onlineConsultationMapper = new OnlineConsultation
            {
                UserId = onlineConsultation.UserId,
                ConsultantId = onlineConsultation.ConsultantId,
                Mode = "Online",
                Status = "Pending",
                JoinUrl = "",
                StartDate = availableSchedule.Slot.StartTime,
                EndDate = availableSchedule.Slot.EndTime,
                SessionCount = 1, // Assuming this is the first session
                Notes = onlineConsultation.Notes,
                IsPregnancyRelated = false,
                UserSubscriptionId = subscription.Id
            };

            await _onlineConsultationRepository.AddAsync(onlineConsultationMapper);

            availableSchedule.Slot.IsAvailable = false;

            _unitOfWork.ScheduleRepository.Update(availableSchedule);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Book online consultation successfully" : "Book online consultation fail",
                Data = _mapper.Map<ViewOnlineConsultationDTO>(onlineConsultationMapper)
            };
        }

        public async Task<Result<bool>> CancelOnlineConsultationAsync(Guid onlineConsultationId)
        {
            var onlineConsultation = await  _onlineConsultationRepository
                .GetOnlineConsultationByIdAsync(onlineConsultationId);

            if (onlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = false
                };
            }

            onlineConsultation.Status = "Cancelled";

            _onlineConsultationRepository.Update(onlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Cancel online consultation successfully" : "Cancel online consultation fail",
                Data = true
            };
        }

        public async Task<Result<bool>> ConfirmOnlineConsultationAsync(Guid onlineConsultationId)
        {
            var onlineConsultation = await _onlineConsultationRepository
                .GetOnlineConsultationByIdAsync(onlineConsultationId);

            if (onlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = false
                };
            }

            onlineConsultation.Status = "Confirmed";

            _onlineConsultationRepository.Update(onlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Confirm online consultation successfully" : "Confirm online consultation fail",
                Data = true
            };
        }

        public async Task<Result<ViewOnlineConsultationDTO>> GetOnlineConsultationByIdAsync(Guid onlineConsultationId)
        {
            var result = _mapper.Map<ViewOnlineConsultationDTO>(
                await _onlineConsultationRepository.GetOnlineConsultationByIdAsync(onlineConsultationId));

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsAsync(Guid consultantId, string? status)
        {
            var result = _mapper.Map<List<ViewOnlineConsultationDTO>>(
                await _onlineConsultationRepository.GetOnlineConsultationsByConsultantIdAsync(consultantId, status));

            return new Result<List<ViewOnlineConsultationDTO>>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteOnlineConsultation(Guid onlineConsultationId)
        {
            var onlineConsultation = await _onlineConsultationRepository.GetOnlineConsultationByIdAsync(onlineConsultationId);

            if (onlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = false
                };
            }

            _onlineConsultationRepository.SoftRemove(onlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove online consultation successfully" : "Remove clinic fail",
                Data = true
            };
        }

        public async Task<Result<ViewOnlineConsultationDTO>> UpdateOnlineConsultation(UpdateOnlineConsultationDTO onlineConsultation)
        {
            var onlineConsultationObj = await _onlineConsultationRepository.GetOnlineConsultationByIdAsync(onlineConsultation.Id);

            if (onlineConsultationObj is null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = null
                };
            }

            _mapper.Map(onlineConsultation, onlineConsultationObj);

            _onlineConsultationRepository.Update(onlineConsultationObj);

            var result = _unitOfWork.SaveChangeAsync().Result;

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update online consultation successfully" : "Update online consultation fail",
                Data = _mapper.Map<ViewOnlineConsultationDTO>(onlineConsultationObj)
            };
        }
    }
}
