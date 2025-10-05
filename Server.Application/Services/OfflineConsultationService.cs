using AutoMapper;
using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OfflineConsultation;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Services
{
    public class OfflineConsultationService : IOfflineConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOfflineConsultationRepository _offlineConsultationRepository;
        private readonly IEmailService _emailService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly INotificationService _notificationService;

        public OfflineConsultationService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOfflineConsultationRepository offlineConsultationRepository,
            IEmailService emailService,
            ICloudinaryService cloudinaryService,
            INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _offlineConsultationRepository = offlineConsultationRepository;
            _emailService = emailService;
            _cloudinaryService = cloudinaryService;
            _notificationService = notificationService;
        }

        public async Task<Result<ViewOfflineConsultationDTO>> BookOfflineConsultationAsync(BookingOfflineConsultationDTO offlineConsultation)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(offlineConsultation.UserId);
            if (user == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = null
                };
            }

            var doctor = await _unitOfWork.DoctorRepository.GetDoctorByIdAsync(offlineConsultation.DoctorId);
            if (doctor == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any doctor, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(doctor.ClinicId);
            if (clinic == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            OfflineConsultation offlineConsultationEntity;

            if (offlineConsultation.ConsultationType == ConsultationType.OneTime)
            {
                if (offlineConsultation.StartDate == null || offlineConsultation.EndDate == null)
                {
                    return new Result<ViewOfflineConsultationDTO>
                    {
                        Error = 1,
                        Message = "StartDate and EndDate are required for OneTime consultation.",
                        Data = null
                    };
                }

                var hasOverlap = await _unitOfWork.DoctorRepository.HasOverlappingScheduleAsync(
                    offlineConsultation.DoctorId,
                    offlineConsultation.StartDate.Value,
                    offlineConsultation.EndDate.Value
                );
                if (hasOverlap)
                {
                    return new Result<ViewOfflineConsultationDTO>
                    {
                        Error = 1,
                        Message = "The selected time slot overlaps with an existing schedule for this doctor.",
                        Data = null
                    };
                }

                offlineConsultationEntity = new OfflineConsultation
                {
                    Id = Guid.NewGuid(),
                    UserId = offlineConsultation.UserId,
                    DoctorId = offlineConsultation.DoctorId,
                    ClinicId = doctor.ClinicId,
                    ConsultationType = ConsultationType.OneTime,
                    Status = "Confirmed",
                    StartDate = offlineConsultation.StartDate.Value,
                    EndDate = offlineConsultation.EndDate.Value,
                    HealthNote = offlineConsultation.HealthNote
                };

                await _offlineConsultationRepository.AddAsync(offlineConsultationEntity);
                await _unitOfWork.SaveChangeAsync();

                // Create slot and schedule, set OfflineConsultationId
                var slot = new Slot
                {
                    StartTime = offlineConsultation.StartDate.Value,
                    EndTime = offlineConsultation.EndDate.Value,
                    IsAvailable = false
                };
                await _unitOfWork.SlotRepository.AddAsync(slot);
                await _unitOfWork.SaveChangeAsync();

                var scheduleEntity = new Schedule
                {
                    SlotId = slot.Id,
                    DoctorId = offlineConsultation.DoctorId,
                    OfflineConsultationId = offlineConsultationEntity.Id
                };
                await _unitOfWork.ScheduleRepository.AddAsync(scheduleEntity);
                await _unitOfWork.SaveChangeAsync();

                offlineConsultationEntity.Schedules = new List<Schedule> { scheduleEntity };
            }
            else if (offlineConsultation.ConsultationType == ConsultationType.Periodic)
            {
                if (offlineConsultation.FromMonth == null || offlineConsultation.ToMonth == null || offlineConsultation.Schedule == null || !offlineConsultation.Schedule.Any())
                {
                    return new Result<ViewOfflineConsultationDTO>
                    {
                        Error = 1,
                        Message = "FromMonth, ToMonth, and Schedule are required for Periodic consultation.",
                        Data = null
                    };
                }

                offlineConsultationEntity = new OfflineConsultation
                {
                    Id = Guid.NewGuid(),
                    UserId = offlineConsultation.UserId,
                    DoctorId = offlineConsultation.DoctorId,
                    ClinicId = doctor.ClinicId,
                    ConsultationType = ConsultationType.Periodic,
                    Status = "Confirmed",
                    FromMonth = offlineConsultation.FromMonth.Value,
                    ToMonth = offlineConsultation.ToMonth.Value,
                    HealthNote = offlineConsultation.HealthNote
                };

                await _offlineConsultationRepository.AddAsync(offlineConsultationEntity);

                var scheduleEntities = new List<Schedule>();
                foreach (var scheduleDto in offlineConsultation.Schedule)
                {
                    var slotDto = scheduleDto.Slot;
                    if (slotDto == null)
                    {
                        continue;
                    }
                    if (slotDto.StartTime < offlineConsultation.FromMonth.Value || slotDto.EndTime > offlineConsultation.ToMonth.Value)
                    {
                        continue;
                    }

                    var hasOverlap = await _unitOfWork.DoctorRepository.HasOverlappingScheduleAsync(
                        offlineConsultation.DoctorId,
                        slotDto.StartTime,
                        slotDto.EndTime
                    );
                    if (hasOverlap)
                    {
                        return new Result<ViewOfflineConsultationDTO>
                        {
                            Error = 1,
                            Message = $"The selected time slot {slotDto.StartTime:dd/MM/yyyy HH:mm} - {slotDto.EndTime:HH:mm} overlaps with an existing schedule for this doctor.",
                            Data = null
                        };
                    }

                    var slot = new Slot
                    {
                        StartTime = slotDto.StartTime,
                        EndTime = slotDto.EndTime,
                        IsAvailable = false
                    };
                    await _unitOfWork.SlotRepository.AddAsync(slot);
                    await _unitOfWork.SaveChangeAsync();

                    var scheduleEntity = new Schedule
                    {
                        SlotId = slot.Id,
                        DoctorId = offlineConsultation.DoctorId,
                        OfflineConsultationId = offlineConsultationEntity.Id
                    };
                    await _unitOfWork.ScheduleRepository.AddAsync(scheduleEntity);
                    await _unitOfWork.SaveChangeAsync();

                    scheduleEntities.Add(scheduleEntity);
                }

                if (!scheduleEntities.Any())
                {
                    return new Result<ViewOfflineConsultationDTO>
                    {
                        Error = 1,
                        Message = "No valid schedules found within the selected period.",
                        Data = null
                    };
                }

                var minStart = scheduleEntities.Min(s => s.Slot.StartTime);
                var maxEnd = scheduleEntities.Max(s => s.Slot.EndTime);

                offlineConsultationEntity.StartDate = minStart;
                offlineConsultationEntity.EndDate = maxEnd;
                offlineConsultationEntity.Schedules = scheduleEntities;
            }
            else
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Invalid consultation type.",
                    Data = null
                };
            }

            _offlineConsultationRepository.Update(offlineConsultationEntity);
            await _unitOfWork.SaveChangeAsync();

            return new Result<ViewOfflineConsultationDTO>
            {
                Error = 0,
                Message = "Offline consultation booked successfully",
                Data = _mapper.Map<ViewOfflineConsultationDTO>(offlineConsultationEntity)
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

                if (user == null)
                {
                    continue; // Skip if user not found
                }

                var doctor = await _unitOfWork.DoctorRepository.GetDoctorByIdAsync(consultation.DoctorId);

                if (doctor == null)
                {
                    continue; // Skip if doctor not found
                }

                var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(doctor.ClinicId);

                if (clinic == null || !clinic.IsActive)
                {
                    continue; // Skip if clinic not found or not active
                }

                // Doctor.User may be null if not included, so check and load if needed
                var doctorUser = doctor?.User;

                if (doctorUser == null && doctor != null)
                    doctorUser = await _unitOfWork.UserRepository.GetByIdAsync(doctor.UserId);

                var doctorName = doctor?.User.UserName ?? "Doctor";
                var username = user.UserName ?? "User";
                var startDate = consultation.StartDate?.ToString("dd/MM/yyyy");
                var endDate = consultation.EndDate?.ToString("dd/MM/yyyy");
                var startTime = consultation.StartDate?.ToString("HH:mm");
                var endTime = consultation.EndDate?.ToString("HH:mm");
                var form = consultation.ConsultationType.ToString();
                var location = clinic?.Address ?? "Clinic";
                var supportContact = clinic?.User.PhoneNumber ?? clinic?.User.Email ?? "our support";
                var detailLink = "update later"; // Replace with actual link if available
                var systemSignature = clinic?.User.UserName ?? "Health Consulting System";

                var emailUserBody = $@"
                                Hi {username},<br/><br/>
                                This is an email reminder that you have a consultation scheduled. Here are the details:<br/><br/>
                                Doctor: {doctorName}<br/>
                                Time: {startDate} to {endDate} – {startTime} to {endTime}<br/>
                                Form: {form}<br/>
                                Location: {location}<br/><br/>
                                👉 Please arrive at least 5 minutes before your appointment time to ensure that your forum consultation is on time and effective.<br/><br/>
                                You can view or manage your consultation schedule at:<br/>
                                If you need further assistance, please contact us via {supportContact}.<br/><br/>
                                Congratulations on a successful consultation!<br/><br/>
                                Best regards,<br/>
                                {systemSignature}";

                var emailDoctorBody = $@"
                                Hi Doctor {doctorName},<br/><br/>
                                The system would like to remind you that you have an upcoming consultation. The details are as follows:<br/><br/>
                                User: {username}<br/>
                                Time: {startDate} to {endDate} – {startTime} to {endTime}<br/>
                                Form: {form}<br/>
                                Location: {location}<br/>
                                You can view details or manage your consultation schedule at the following link:<br/>
                                Best regards,<br/>
                                {systemSignature}";

                // Send reminder to user
                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    var emailUserDTO = new EmailDTO
                    {
                        To = user.Email,
                        Subject = "Offline Consultation Reminder",
                        Body = emailUserBody
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
                        Body = emailDoctorBody
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

            var username = user.UserName ?? "User";
            var doctorName = doctor.User.UserName ?? "Doctor";
            var startTime = offlineConsulattion.StartDate?.ToString("HH:mm");
            var endTime = offlineConsulattion.EndDate?.ToString("HH:mm");
            var startDate = offlineConsulattion.StartDate?.ToString("dd/MM/yyyy");
            var endDate = offlineConsulattion.EndDate?.ToString("dd/MM/yyyy");
            var form = offlineConsulattion.ConsultationType.ToString();
            var location = clinic.Address ?? "Clinic";
            var contact = clinic.User.Email ?? "our support email";
            //var detailLink = $"http://localhost:5173/offline-consultation/{offlineConsultationId}"; // Local
            var detailLink = $"https://nestlycare.live/offline-consultation/{offlineConsultationId}"; // Local
            var systemSignature = clinic?.User.UserName ?? "Health Consulting System";

            var emailUserBody = $@"
                            Hi {username},<br/><br/>
                            We would like to inform you that your consultation has been successfully booked with the following information:<br/><br/>
                            Doctor: {doctorName}<br/>
                            Time: {startDate} to {endDate} - {startTime} to {endTime}<br/>
                            Form: {form}<br/>
                            Location: {location}<br/><br/>
                            Please prepare in advance the questions or issues you want to discuss to make the consultation most effective.<br/><br/>
                            You can view the consultation details at the following link:<br/>
                            <a href=""{detailLink}"">View consultation details</a><br/><br/>
                            We will send a reminder before the consultation takes place.<br/><br/>
                            If you have any questions, do not hesitate to contact us via {contact}.<br/><br/>
                            Thank you for trusting and choosing our service!<br/><br/>
                            Best regards,<br/>
                            {systemSignature}";

            var emailDoctorBody = $@"
                            Hi Doctor {doctorName},<br/><br/>
                            You have just been assigned to a new consultation with a user. Here are the details:<br/><br/>
                            User: {username}<br/>
                            Time: {startDate} to {endDate} - {startTime} to {endTime}<br/>
                            Form: {form}<br/>
                            Location: {location}<br/><br/>
                            Please check your schedule to ensure you can attend on time.<br/><br/>
                            You can view the consultation details at the following link:<br/>
                            <a href=""{detailLink}"">View consultation details</a><br/><br/>
                            Best regards,<br/>
                            {systemSignature}";

            // Send email to user
            if (!string.IsNullOrEmpty(user.Email))
            {
                var emailUserDTO = new EmailDTO
                {
                    To = user.Email,
                    Subject = "Offline Consultation Booked",
                    Body = emailUserBody
                };

                await _emailService.SendEmailAsync(emailUserDTO);
            }
            // same for onlinecon i did not test this code yet ~
            // update dto payload
            var offlineConsulattionDto = new
            {
                offlineConsulattion.Id,
                offlineConsulattion.UserId,
                offlineConsulattion.ClinicId,
                offlineConsulattion.DoctorId,
                offlineConsulattion.ConsultationType,
                offlineConsulattion.StartDate,
                offlineConsulattion.EndDate,
                offlineConsulattion.HealthNote,
                Media = offlineConsulattion.Attachments.Select(m => new { m.FileUrl, m.FileType }),
            };
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Message = $"You have booked a new offline consultation on {startDate} with the doctor {doctorName} at {location}",
                CreatedBy = user.Id,
                IsSent = true,
                IsRead = false,
                CreationDate = DateTime.UtcNow.Date
            };

            await _notificationService.CreateNotification(notification, offlineConsulattionDto, "OfflineConsultation");

            // Send email to doctor
            if (!string.IsNullOrEmpty(doctor.User.Email))
            {
                var emailDoctorDTO = new EmailDTO
                {
                    To = doctor.User.Email,
                    Subject = "Offline Consultation Booked",
                    Body = emailDoctorBody
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

        public async Task<Result<List<ViewOfflineConsultationDTO>>> GetOfflineConsultationsByCreatedByAsync(Guid userId)
        {
            var result = _mapper.Map<List<ViewOfflineConsultationDTO>>(
                await _offlineConsultationRepository.GetOfflineConsultationsByCreatedByAsync(userId));

            return new Result<List<ViewOfflineConsultationDTO>>
            {
                Error = 0,
                Message = "View offline consultation successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> AddAttachmentsAsync(Guid offlineConsultationId, List<IFormFile> attachments)
        {
            var offlineConsultation = await _offlineConsultationRepository
                .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultationId);

            if (offlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Offline consultation not found.",
                    Data = false
                };
            }

            if (attachments == null || !attachments.Any())
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "No attachments provided.",
                    Data = false
                };
            }

            foreach (var file in attachments)
            {
                var response = await _cloudinaryService.UploadOfflineConsultationAttachment(
                    file.FileName, file, offlineConsultation);

                if (response != null)
                {
                    var media = new Media
                    {
                        OfflineConsultationId = offlineConsultation.Id,
                        FileName = file.FileName,
                        FileUrl = response.FileUrl,
                        FilePublicId = response.PublicFileId,
                        FileType = file.ContentType
                    };
                    await _unitOfWork.MediaRepository.AddAsync(media);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                        offlineConsultation.Attachments.Add(media);
                }
            }

            _offlineConsultationRepository.Update(offlineConsultation);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Attachments added successfully." : "Failed to add attachments.",
                Data = result > 0
            };
        }

        public async Task<Result<ViewOfflineConsultationDTO>> UpdateOfflineConsultationAsync(UpdateOfflineConsultationDTO offlineConsultation)
        {
            var offlineConsultationObj = await _offlineConsultationRepository
                .GetOfflineConsultationByOfflineConsultationIdAsync(offlineConsultation.Id);

            if (offlineConsultationObj == null)
            {
                return new Result<ViewOfflineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any offline consultation, please try again!",
                    Data = null
                };
            }

            // Update for OneTime consultation
            if (offlineConsultationObj.ConsultationType == ConsultationType.OneTime)
            {
                if (offlineConsultation.StartDate != null)
                    offlineConsultationObj.StartDate = offlineConsultation.StartDate;
                if (offlineConsultation.EndDate != null)
                    offlineConsultationObj.EndDate = offlineConsultation.EndDate;
            }
            // Update for Periodic consultation
            else if (offlineConsultationObj.ConsultationType == ConsultationType.Periodic)
            {
                if (offlineConsultation.FromMonth != null)
                    offlineConsultationObj.FromMonth = offlineConsultation.FromMonth;
                if (offlineConsultation.ToMonth != null)
                    offlineConsultationObj.ToMonth = offlineConsultation.ToMonth;

                if (offlineConsultation.Schedule != null && offlineConsultation.Schedule.Any())
                {
                    offlineConsultationObj.Schedules?.Clear();
                    foreach (var scheduleDto in offlineConsultation.Schedule)
                    {
                        var scheduleEntity = _mapper.Map<Schedule>(scheduleDto);
                        scheduleEntity.OfflineConsultationId = offlineConsultationObj.Id;
                        offlineConsultationObj.Schedules?.Add(scheduleEntity);
                    }
                }

                if (offlineConsultationObj.Schedules != null && offlineConsultationObj.Schedules.Any())
                {
                    var minStart = offlineConsultationObj.Schedules
                        .Where(s => s.Slot != null)
                        .Min(s => s.Slot.StartTime);

                    var maxEnd = offlineConsultationObj.Schedules
                        .Where(s => s.Slot != null)
                        .Max(s => s.Slot.EndTime);

                    offlineConsultation.StartDate = minStart;
                    offlineConsultation.EndDate = maxEnd;
                }
            }

            if (offlineConsultation.Attachments == null)
            {
                if (offlineConsultationObj.Attachments != null && offlineConsultationObj.Attachments.Any())
                {
                    foreach (var existingMedia in offlineConsultationObj.Attachments.ToList())
                    {
                        if (!string.IsNullOrEmpty(existingMedia.FilePublicId))
                        {
                            await _cloudinaryService.DeleteFileAsync(existingMedia.FilePublicId);
                        }
                    }
                    offlineConsultationObj.Attachments.Clear();
                }
            }
            else
            {
                if (offlineConsultationObj.Attachments != null && offlineConsultationObj.Attachments.Any())
                {
                    foreach (var existingMedia in offlineConsultationObj.Attachments.ToList())
                    {
                        if (!string.IsNullOrEmpty(existingMedia.FilePublicId))
                        {
                            await _cloudinaryService.DeleteFileAsync(existingMedia.FilePublicId);
                        }
                    }
                    offlineConsultationObj.Attachments.Clear();
                }
                if (offlineConsultation.Attachments.Any())
                {
                    if (offlineConsultation.Attachments.Count > 4)
                    {
                        return new Result<ViewOfflineConsultationDTO>
                        {
                            Error = 1,
                            Message = "You can upload a maximum of 4 attachments per consultation.",
                            Data = null
                        };
                    }

                    foreach (var attachment in offlineConsultation.Attachments)
                    {
                        var response = await _cloudinaryService.UploadOfflineConsultationAttachment(
                            attachment.FileName, attachment, offlineConsultationObj);

                        if (response != null)
                        {
                            offlineConsultationObj.Attachments.Add(new Media
                            {
                                OfflineConsultationId = offlineConsultationObj.Id,
                                FileName = attachment.FileName,
                                FileUrl = response.FileUrl,
                                FilePublicId = response.PublicFileId,
                                FileType = attachment.ContentType
                            });
                        }
                    }
                }
            }

            _mapper.Map(offlineConsultation, offlineConsultationObj);

            _offlineConsultationRepository.Update(offlineConsultationObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewOfflineConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update offline consultation successfully" : "Update offline consultation fail",
                Data = result > 0 ? _mapper.Map<ViewOfflineConsultationDTO>(offlineConsultationObj) : null
            };
        }

        public async Task<Result<bool>> SendUpdatedBookingEmailAsync(Guid offlineConsultationId)
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

            var username = user.UserName ?? "User";
            var doctorName = doctor.User.UserName ?? "Doctor";
            var startTime = offlineConsulattion.StartDate?.ToString("HH:mm");
            var endTime = offlineConsulattion.EndDate?.ToString("HH:mm");
            var startDate = offlineConsulattion.StartDate?.ToString("dd/MM/yyyy");
            var endDate = offlineConsulattion.EndDate?.ToString("dd/MM/yyyy");
            var form = offlineConsulattion.ConsultationType.ToString();
            var location = clinic.Address ?? "Clinic";
            var contact = clinic.User.Email ?? "our support email";
            //var detailLink = $"http://localhost:5173/offline-consultation/{offlineConsultationId}"; // Local
            var detailLink = $"https://nestlycare.live/offline-consultation/{offlineConsultationId}"; // Local
            var systemSignature = clinic?.User.UserName ?? "Health Consulting System";

            var emailUserBody = $@"
                                Hi {username},<br/><br/>
                                We would like to inform you that the information for your <b>online consultation</b> has been <b>successfully updated</b> with the following details:<br/><br/>
                                Doctor: {doctorName}<br/>
                                Time: {startDate} to {endDate} - {startTime} to {endTime}<br/>
                                Form: {form}<br/>
                                Location: {location}<br/><br/>
                                Please review the updated information to make sure everything is correct.<br/>
                                You can view the full consultation details at the link below:<br/>
                                🔗 <a href=""{detailLink}"">View updated consultation details</a><br/><br/>
                                We will send you a reminder before the consultation begins.<br/><br/>
                                If you have any questions or need to make further changes, please contact us via {contact}.<br/><br/>
                                Thank you for trusting and choosing our online consultation service!<br/><br/>
                                Best regards,<br/>
                                {systemSignature}";

            var emailDoctorBody = $@"
                                Hi Doctor {doctorName},<br/><br/>
                                We would like to inform you that the information for your <b>online consultation</b> with the user has been <b>successfully updated</b>. Please find the updated details below:<br/><br/>
                                User: {username}<br/>
                                Time: {startDate} to {endDate} - {startTime} to {endTime}<br/>
                                Form: {form}<br/>
                                Location: {location}<br/><br/>
                                Please review the updated schedule to ensure you are available at the specified time.<br/><br/>
                                You can view the full consultation details at the following link:<br/>
                                🔗 <a href=""{detailLink}"">View updated consultation details</a><br/><br/>
                                Best regards,<br/>
                                {systemSignature}";

            // Send email to user
            if (!string.IsNullOrEmpty(user.Email))
            {
                var emailUserDTO = new EmailDTO
                {
                    To = user.Email,
                    Subject = "Offline Consultation Booked",
                    Body = emailUserBody
                };

                await _emailService.SendEmailAsync(emailUserDTO);
            }
            // same for onlinecon i did not test this code yet ~
            // update dto payload
            var offlineConsulattionDto = new
            {
                offlineConsulattion.Id,
                offlineConsulattion.UserId,
                offlineConsulattion.ClinicId,
                offlineConsulattion.DoctorId,
                offlineConsulattion.ConsultationType,
                offlineConsulattion.StartDate,
                offlineConsulattion.EndDate,
                offlineConsulattion.HealthNote,
                Media = offlineConsulattion.Attachments.Select(m => new { m.FileUrl, m.FileType }),
            };
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Message = $"You have booked a new offline consultation on {startDate} with the doctor {doctorName} at {location}",
                CreatedBy = user.Id,
                IsSent = true,
                IsRead = false,
                CreationDate = DateTime.UtcNow.Date
            };

            await _notificationService.CreateNotification(notification, offlineConsulattionDto, "OfflineConsultation");

            // Send email to doctor
            if (!string.IsNullOrEmpty(doctor.User.Email))
            {
                var emailDoctorDTO = new EmailDTO
                {
                    To = doctor.User.Email,
                    Subject = "Offline Consultation Booked",
                    Body = emailDoctorBody
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
