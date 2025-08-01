﻿using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OfflineConsultation;
using Server.Application.DTOs.User;
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
        private readonly IEmailService _emailService;
        private readonly ICloudinaryService _cloudinaryService;

        public OfflineConsultationService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOfflineConsultationRepository offlineConsultationRepository,
            IEmailService emailService,
            ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _offlineConsultationRepository = offlineConsultationRepository;
            _emailService = emailService;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Result<ViewOfflineConsultationDTO>> BookOfflineConsultationAsync(BookingOfflineConsultationDTO offlineConsultation)
        {
            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(offlineConsultation.UserId);

            if (user == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = null
                };
            }

            var doctor = await _unitOfWork.DoctorRepository
                .GetDoctorByIdAsync(offlineConsultation.DoctorId);

            if (doctor == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any doctor, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(doctor.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            var hasOverlap = await _unitOfWork.DoctorRepository
                .HasOverlappingScheduleAsync(offlineConsultation.DoctorId,
                    offlineConsultation.Schedule.Slot.StartTime,
                    offlineConsultation.Schedule.Slot.EndTime,
                    offlineConsultation.Schedule.Slot.DayOfWeek);

            if (hasOverlap)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "The selected time slot overlaps with an existing schedule for this doctor.",
                    Data = null
                };
            }

            var slot = _mapper.Map<Slot>(offlineConsultation.Schedule.Slot);

            slot.IsAvailable = false;

            await _unitOfWork.SlotRepository.AddAsync(slot);

            var slotSaveResult = await _unitOfWork.SaveChangeAsync();

            if (slotSaveResult <= 0)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Failed to create slot.",
                    Data = null
                };
            }

            var scheduleEntity = new Schedule
            {
                SlotId = slot.Id,
                DoctorId = offlineConsultation.DoctorId
            };

            await _unitOfWork.ScheduleRepository.AddAsync(scheduleEntity);

            var scheduleSaveResult = await _unitOfWork.SaveChangeAsync();

            if (scheduleSaveResult <= 0)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Failed to create schedule.",
                    Data = null
                };
            }

            var attachments = new List<Media>();

            var offlineConsulattionMapper = new OfflineConsultation
            {
                Id = Guid.NewGuid(),
                UserId = offlineConsultation.UserId,
                DoctorId = offlineConsultation.DoctorId,
                ClinicId = doctor.ClinicId,
                ConsultationType = offlineConsultation.ConsultationType,
                Status = "Confirmed",
                StartDate = offlineConsultation.Schedule.Slot.StartTime,
                EndDate = offlineConsultation.Schedule.Slot.EndTime,
                DayOfWeek = offlineConsultation.Schedule.Slot.DayOfWeek,
                HealthNote = offlineConsultation.HealthNote,
                Attachments = attachments
            };

            await _offlineConsultationRepository.AddAsync(offlineConsulattionMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            if (result <= 0)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Failed to book offline consultation.",
                    Data = null
                };
            }

            if (offlineConsultation.Attachments != null && offlineConsultation.Attachments.Any())
            {
                foreach (var file in offlineConsultation.Attachments)
                {
                    var response = await _cloudinaryService.UploadOfflineConsultationAttachment(
                        file.FileName, file, offlineConsulattionMapper);

                    if (response != null)
                    {
                        var media = new Media
                        {
                            OfflineConsultationId = offlineConsulattionMapper.Id,
                            FileName = file.FileName,
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = file.ContentType
                        };
                        await _unitOfWork.MediaRepository.AddAsync(media);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                            offlineConsulattionMapper.Attachments.Add(media);
                    }
                }

                _offlineConsultationRepository.Update(offlineConsulattionMapper);

                await _unitOfWork.SaveChangeAsync();
            }

            return new Result<ViewOfflineConsultationDTO>
            {
                Error = 0,
                Message = "Offline consultation booked successfully",
                Data = _mapper.Map<ViewOfflineConsultationDTO>(offlineConsulattionMapper)
            };
        }

        //public async Task<Result<bool>> CancelOfflineConsultationAsync(Guid offlineConsultationId)
        //{
        //    var offlineConsultation = await _offlineConsultationRepository
        //        .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultationId);

        //    if (offlineConsultation == null)
        //    {
        //        return new Result<bool>
        //        {
        //            Error = 1,
        //            Message = "Didn't find any offline consultation, please try again!",
        //            Data = false
        //        };
        //    }

        //    offlineConsultation.Status = "Cancelled";

        //    _offlineConsultationRepository.Update(offlineConsultation);

        //    var consultant = await _unitOfWork.ConsultantRepository
        //        .GetConsultantByIdAsync(offlineConsultation.ConsultantId);

        //    if (consultant != null)
        //    {
        //        var scheduleList = await _unitOfWork.ScheduleRepository
        //            .FindAsync(s =>
        //                s.ConsultantId == consultant.Id &&
        //                s.Slot != null &&
        //                s.Slot.StartTime == offlineConsultation.StartDate &&
        //                s.Slot.EndTime == offlineConsultation.EndDate);

        //        var scheduleEntity = scheduleList.FirstOrDefault();
        //        if (scheduleEntity?.Slot != null)
        //        {
        //            var slot = await _unitOfWork.SlotRepository.GetByIdAsync(scheduleEntity.Slot.Id);
        //            if (slot != null)
        //            {
        //                slot.IsAvailable = false;
        //                _unitOfWork.SlotRepository.Update(slot);
        //            }
        //        }
        //    }

        //    var result = await _unitOfWork.SaveChangeAsync();

        //    return new Result<bool>
        //    {
        //        Error = result > 0 ? 0 : 1,
        //        Message = result > 0 ? "Cancel offline consultation successfully" : "Cancel offline consultation fail",
        //        Data = true
        //    };
        //}

        //public async Task<Result<bool>> ConfirmOfflineConsultationAsync(Guid offlineConsultationId)
        //{
        //    var offlineConsultation = await _offlineConsultationRepository
        //        .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultationId);

        //    if (offlineConsultation == null)
        //    {
        //        return new Result<bool>
        //        {
        //            Error = 1,
        //            Message = "Didn't find any offline consultation, please try again!",
        //            Data = false
        //        };
        //    }

        //    offlineConsultation.Status = "Confirmed";

        //    _offlineConsultationRepository.Update(offlineConsultation);

        //    var consultant = await _unitOfWork.ConsultantRepository
        //        .GetConsultantByIdAsync(offlineConsultation.ConsultantId);

        //    if (consultant != null)
        //    {
        //        var scheduleList = await _unitOfWork.ScheduleRepository
        //            .FindAsync(s =>
        //                s.ConsultantId == consultant.Id &&
        //                s.Slot != null &&
        //                s.Slot.StartTime == offlineConsultation.StartDate &&
        //                s.Slot.EndTime == offlineConsultation.EndDate);

        //        var scheduleEntity = scheduleList.FirstOrDefault();
        //        if (scheduleEntity?.Slot != null)
        //        {
        //            var slot = await _unitOfWork.SlotRepository.GetByIdAsync(scheduleEntity.Slot.Id);
        //            if (slot != null)
        //            {
        //                slot.IsAvailable = false;
        //                _unitOfWork.SlotRepository.Update(slot);
        //            }
        //        }
        //    }

        //    var result = await _unitOfWork.SaveChangeAsync();

        //    return new Result<bool>
        //    {
        //        Error = result > 0 ? 0 : 1,
        //        Message = result > 0 ? "Confirm offline consultation successfully" : "Confirm offline consultation fail",
        //        Data = true
        //    };
        //}

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

        public async Task SendOfflineConsultationRemindersAsync()
        {
            var tomorrow = DateTime.Now.Date.AddDays(1);
            var dayAfterTomorrow = tomorrow.AddDays(1);

            // Get all consultations scheduled for tomorrow and confirmed
            var consultations = await _offlineConsultationRepository
                .FindAsync(c =>
                    c.StartDate >= tomorrow &&
                    c.StartDate < dayAfterTomorrow &&
                    c.Status == "Confirmed");

            foreach (var consultation in consultations)
            {
                // Get user and doctor
                var user = await _unitOfWork.UserRepository.GetByIdAsync(consultation.UserId);

                var doctor = await _unitOfWork.DoctorRepository.GetDoctorByIdAsync(consultation.DoctorId);

                var dayOfWeekName = GetDayOfWeekName(consultation.DayOfWeek);

                // Doctor.User may be null if not included, so check and load if needed
                var doctorUser = doctor?.User;

                if (doctorUser == null && doctor != null)
                    doctorUser = await _unitOfWork.UserRepository.GetByIdAsync(doctor.UserId);

                // Send reminder to user
                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    var emailUserDTO = new EmailDTO
                    {
                        To = user.Email,
                        Subject = "Offline Consultation Reminder",
                        Body = $"This is a reminder for your offline consultation scheduled at" +
                        $" {dayOfWeekName}, {consultation.StartDate:yyyy-MM-dd HH:mm}."
                    };

                    await _emailService.SendEmailAsync(emailUserDTO);
                }

                // Send reminder to doctor
                if (doctorUser != null && !string.IsNullOrEmpty(doctorUser.Email))
                {
                    var emailDoctorDTO = new EmailDTO
                    {
                        To = doctorUser.Email,
                        Subject = "Offline Consultation Reminder",
                        Body = $"This is a reminder that you have an offline consultation scheduled" +
                        $" with {user.UserName} at {dayOfWeekName},  {consultation.StartDate:yyyy-MM-dd HH:mm}."
                    };

                    await _emailService.SendEmailAsync(emailDoctorDTO);
                }
            }
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

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(offlineConsultation.ClinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot remove offline consultation.",
                    Data = false
                };
            }

            _offlineConsultationRepository.SoftRemove(offlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove offline consultation successfully" : "Remove offline consultation fail",
                Data = result > 0
            };
        }

        private static string GetDayOfWeekName(int dayOfWeek)
        {
            return Enum.IsDefined(typeof(DayOfWeek), dayOfWeek)
                ? ((DayOfWeek)dayOfWeek).ToString()
                : "Unknown";
        }

        public async Task<Result<bool>> SendBookingEmailAsync(Guid offlineConsultationId)
        {
            var offlineConsulattion = await _offlineConsultationRepository
                .GetOfflineConsultationByIdAsync(offlineConsultationId);

            if (offlineConsulattion == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any offline consultation, please try again!",
                    Data = false
                };
            }

            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(offlineConsulattion.UserId);

            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = false
                };
            }

            var doctor = await _unitOfWork.DoctorRepository
                .GetDoctorByIdAsync(offlineConsulattion.DoctorId);

            if (doctor == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any doctor, please try again!",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(doctor.ClinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot send booking email.",
                    Data = false
                };
            }

            var dayOfWeekName = GetDayOfWeekName(offlineConsulattion.DayOfWeek);

            // Send email to user
            if (!string.IsNullOrEmpty(user.Email))
            {
                var emailUserDTO = new EmailDTO
                {
                    To = user.Email,
                    Subject = "Offline Consultation Booked",
                    Body = $"Your offline consultation with Dr. {doctor.FullName ?? "Doctor"}" +
                           $" at {clinic.Name} has been successfully booked for " +
                           $"{dayOfWeekName}, " +
                           $"{offlineConsulattion.StartDate: dd/MM/yyyy HH:mm}."
                };

                await _emailService.SendEmailAsync(emailUserDTO);
            }

            // Send email to doctor
            if (!string.IsNullOrEmpty(doctor.User.Email))
            {
                var emailDoctorDTO = new EmailDTO
                {
                    To = doctor.User.Email,
                    Subject = "Offline Consultation Booked",
                    Body = $"You have a new offline consultation booked with {user.UserName} " +
                           $"at {clinic.Name} for {dayOfWeekName}, " +
                           $"{offlineConsulattion.StartDate: dd/MM/yyyy HH:mm}."
                };
                await _emailService.SendEmailAsync(emailDoctorDTO);
            }

            return new Result<bool>
            {
                Error = 0,
                Message = "Booking email sent successfully",
                Data = true
            };
        }
    }
}
