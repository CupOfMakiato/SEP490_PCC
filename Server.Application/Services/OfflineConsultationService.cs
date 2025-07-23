using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OfflineConsultation;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class OfflineConsultationService : IOfflineConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOfflineConsultationRepository _offlineConsultationRepository;

        public OfflineConsultationService(IUnitOfWork unitOfWork, IMapper mapper, IOfflineConsultationRepository offlineConsultationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _offlineConsultationRepository = offlineConsultationRepository;
        }

        public async Task<Result<bool>> BookOfflineConsultationAsync(BookingOfflineConsultationDTO offlineConsultation)
        {
            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(offlineConsultation.UserId);

            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = false
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository
                .GetByIdAsync(offlineConsultation.ConsultantId);

            if (consultant == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = false
                };
            }

            var schedule = await _unitOfWork.ScheduleRepository
                .GetScheduleAvailableByIdAsync(offlineConsultation.ScheduleId);

            if (schedule == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any schedule, please try again!",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetByIdAsync(offlineConsultation.ClinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            var availableSchdeule = await _unitOfWork.ScheduleRepository
                .GetScheduleAvailableByIdAsync(offlineConsultation.ScheduleId);

            if (availableSchdeule == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Schedule is not available or does not exist.",
                    Data = false
                };
            }

            var offlineConsulattionMapper = new OfflineConsultation
            {
                UserId = offlineConsultation.UserId,
                ConsultantId = offlineConsultation.ConsultantId,
                ClinicId = offlineConsultation.ClinicId,
                ConsultationType = offlineConsultation.ConsultationType,
                Status = "Pending",
                StartDate = availableSchdeule.Slot.StartTime,
                EndDate = availableSchdeule.Slot.EndTime,
                HealthNote = offlineConsultation.HealthNote,
                Attachment = offlineConsultation.Attachment
            };

            await _offlineConsultationRepository.AddAsync(offlineConsulattionMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Offline consultation booked successfully" : "Book offline consultation fail",
                Data = true
            };
        }

        public async Task<Result<bool>> CancelOfflineConsultationAsync(Guid offlineConsultationId)
        {
            var offlineConsultation = await _offlineConsultationRepository
                .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultationId);

            if (offlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any offline consultation, please try again!",
                    Data = false
                };
            }

            offlineConsultation.Status = "Cancelled";

            _offlineConsultationRepository.Update(offlineConsultation);

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(offlineConsultation.ConsultantId);

            if (consultant != null)
            {
                var scheduleList = await _unitOfWork.ScheduleRepository
                    .FindAsync(s =>
                        s.ConsultantId == consultant.Id &&
                        s.Slot != null &&
                        s.Slot.StartTime == offlineConsultation.StartDate &&
                        s.Slot.EndTime == offlineConsultation.EndDate);

                var scheduleEntity = scheduleList.FirstOrDefault();
                if (scheduleEntity?.Slot != null)
                {
                    var slot = await _unitOfWork.SlotRepository.GetByIdAsync(scheduleEntity.Slot.Id);
                    if (slot != null)
                    {
                        slot.IsAvailable = false;
                        _unitOfWork.SlotRepository.Update(slot);
                    }
                }
            }

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Cancel offline consultation successfully" : "Cancel offline consultation fail",
                Data = true
            };
        }

        public async Task<Result<bool>> ConfirmOfflineConsultationAsync(Guid offlineConsultationId)
        {
            var offlineConsultation = await _offlineConsultationRepository
                .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultationId);

            if (offlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any offline consultation, please try again!",
                    Data = false
                };
            }

            offlineConsultation.Status = "Confirmed";

            _offlineConsultationRepository.Update(offlineConsultation);

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(offlineConsultation.ConsultantId);

            if (consultant != null)
            {
                var scheduleList = await _unitOfWork.ScheduleRepository
                    .FindAsync(s =>
                        s.ConsultantId == consultant.Id &&
                        s.Slot != null &&
                        s.Slot.StartTime == offlineConsultation.StartDate &&
                        s.Slot.EndTime == offlineConsultation.EndDate);

                var scheduleEntity = scheduleList.FirstOrDefault();
                if (scheduleEntity?.Slot != null)
                {
                    var slot = await _unitOfWork.SlotRepository.GetByIdAsync(scheduleEntity.Slot.Id);
                    if (slot != null)
                    {
                        slot.IsAvailable = false;
                        _unitOfWork.SlotRepository.Update(slot);
                    }
                }
            }

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Confirm offline consultation successfully" : "Confirm offline consultation fail",
                Data = true
            };
        }

        public async Task<Result<ViewOfflineConsultationDTO>> GetOfflineConsultationByIdAsync(Guid offlineConsultationId)
        {
            var result = _mapper.Map<ViewOfflineConsultationDTO>(
                await _offlineConsultationRepository.GetOfflineConsultationByIdAsync(offlineConsultationId));

            return new Result<ViewOfflineConsultationDTO>
            {
                Error = 0,
                Message = "View offline consultation successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewOfflineConsultationDTO>>> GetOfflineConsultationsByUserIdAsync(Guid userId, string? status)
        {
            var result = _mapper.Map<List<ViewOfflineConsultationDTO>>(
                await _offlineConsultationRepository.GetAllOfflineConsultationByUserIdAsync(userId, status));

            return new Result<List<ViewOfflineConsultationDTO>>
            {
                Error = 0,
                Message = "View offline consultation successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteOfflineConsultation(Guid offlineConsultationId)
        {
            var offlineConsultation = await _offlineConsultationRepository
                .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultationId);

            if (offlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any offline consultation, please try again!",
                    Data = false
                };
            }

            _offlineConsultationRepository.SoftRemove(offlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove offline consultation successfully" : "Remove offline consultation fail",
                Data = true
            };
        }
    }
}
