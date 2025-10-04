using AutoMapper;
using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OnlineConsultation;
using Server.Application.DTOs.User;
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
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;

        public OnlineConsultationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOnlineConsultationRepository onlineConsultationRepository,
            ICloudinaryService cloudinaryService,
            IEmailService emailService,
            INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _onlineConsultationRepository = onlineConsultationRepository;
            _cloudinaryService = cloudinaryService;
            _emailService = emailService;
            _notificationService = notificationService;
        }

        public async Task<Result<ViewOnlineConsultationDTO>> CreateOnlineConsultation(AddOnlineConsultationDTO onlineConsultation)
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

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(onlineConsultation.ConsultantId);

            if (consultant == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot create online consultation.",
                    Data = null
                };
            }

            var attachments = new List<Media>();

            var onlineConsultationMapper = new OnlineConsultation
            {
                UserId = onlineConsultation.UserId,
                ConsultantId = onlineConsultation.ConsultantId,
                Trimester = onlineConsultation.Trimester,
                Date = onlineConsultation.Date,
                GestationalWeek = onlineConsultation.GestationalWeek,
                Summary = onlineConsultation.Summary,
                ConsultantNote = onlineConsultation.ConsultantNote,
                UserNote = onlineConsultation.UserNote,
                VitalSigns = onlineConsultation.VitalSigns,
                Recommendations = onlineConsultation.Recommendations,
                Attachments = attachments
            };

            await _onlineConsultationRepository.AddAsync(onlineConsultationMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            if (result <= 0)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Create online consultation fail",
                    Data = null
                };
            }

            if (onlineConsultation.Attachments != null && onlineConsultation.Attachments.Any())
            {
                foreach (var file in onlineConsultation.Attachments)
                {
                    var response = await _cloudinaryService.UploadOnlineConsultationAttachment(
                        file.FileName, file, onlineConsultationMapper);

                    if (response != null)
                    {
                        var media = new Media
                        {
                            OnlineConsultationId = onlineConsultationMapper.Id,
                            FileName = file.FileName,
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = file.ContentType,
                        };
                        await _unitOfWork.MediaRepository.AddAsync(media);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                            onlineConsultationMapper.Attachments.Add(media);
                    }
                }

                _onlineConsultationRepository.Update(onlineConsultationMapper);

                await _unitOfWork.SaveChangeAsync();
            }

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = 0,
                Message = "Create online consultation successfully",
                Data = _mapper.Map<ViewOnlineConsultationDTO>(onlineConsultationMapper)
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

        public async Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsByConsultantIdAsync(Guid consultantId)
        {
            var result = _mapper.Map<List<ViewOnlineConsultationDTO>>(
                await _onlineConsultationRepository.GetOnlineConsultationsByConsultantIdAsync(consultantId));

            return new Result<List<ViewOnlineConsultationDTO>>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsByUserIdAsync(Guid userId)
        {
            var result = _mapper.Map<List<ViewOnlineConsultationDTO>>(
                await _onlineConsultationRepository.GetOnlineConsultationsByUserIdAsync(userId));

            return new Result<List<ViewOnlineConsultationDTO>>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SendBookingEmailAsync(Guid onlineConsultationId)
        {
            var onlineConsultation = await _onlineConsultationRepository
                .GetOnlineConsultationByOnlineConsultationIdAsync(onlineConsultationId);

            if (onlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = false
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(onlineConsultation.ConsultantId);

            if (consultant == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(consultant.ClinicId);

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
                    Message = "Clinic is not active, cannot send email.",
                    Data = false
                };
            }

            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(onlineConsultation.UserId);

            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = false
                };
            }

            // Prepare email body with placeholders replaced
            var consultantName = consultant.User?.UserName ?? "Consultant";
            var consultationDateTime = onlineConsultation.Date.ToString("dd/MM/yyyy HH:mm");
            var username = user.UserName ?? "User";
            var viewLink = $"http://localhost:5173/online-consultation/{onlineConsultationId}"; // local
            var systemSignature = clinic?.User.UserName ?? "Health Consulting System";

            var emailBody = $@"
                            Hi {username},<br/><br/>
                            We would like to inform you that the information of the last consultation with {consultantName} at {consultationDateTime} has been successfully saved by the system.<br/><br/>
                            You can review the content or notes from the consultation at the following link:<br/>
                            🔗 <a href=""{viewLink}"">View consultation details</a><br/><br/>
                            This storage helps you easily track the progress and information exchanged in previous consultations.<br/><br/>
                            If you have any questions, do not hesitate to contact us via {clinic?.User.Email}.<br/><br/>
                            Thank you for trusting and choosing our service!<br/><br/>
                            Best regards,<br/>
                            {systemSignature}";

            // Send email to user
            if (!string.IsNullOrEmpty(user.Email))
            {
                var emailUserDTO = new EmailDTO
                {
                    To = user.Email,
                    Subject = "Online Consultation",
                    Body = emailBody
                };

                await _emailService.SendEmailAsync(emailUserDTO);
            }

            // update dto payload
            var onlineConsultationDto = new
            {
                onlineConsultation.Id,
                onlineConsultation.UserId,
                onlineConsultation.ConsultantId,
                onlineConsultation.Trimester,
                onlineConsultation.Date,
                onlineConsultation.GestationalWeek,
                onlineConsultation.Summary,
                onlineConsultation.ConsultantNote,
                onlineConsultation.UserNote,
                onlineConsultation.VitalSigns,
                onlineConsultation.Recommendations,
                Media = onlineConsultation.Attachments.Select(m => new { m.FileUrl, m.FileType }),
            };
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Message = $"You have booked a new online consultation on {consultationDateTime} with {consultantName}",
                CreatedBy = user.Id,
                IsSent = true,
                IsRead = false,
                CreationDate = DateTime.UtcNow.Date
            };

            await _notificationService.CreateNotification(notification, onlineConsultationDto, "OnlineConsultation");

            return new Result<bool>
            {
                Error = 0,
                Message = "Online consultation email sent successfully",
                Data = true
            };
        }

        public async Task<Result<bool>> SoftDeleteOnlineConsultation(Guid onlineConsultationId)
        {
            var onlineConsultation = await _onlineConsultationRepository
                .GetOnlineConsultationByOnlineConsultationIdAsync(onlineConsultationId);

            if (onlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = false
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(onlineConsultation.ConsultantId);
            
            if (consultant == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(consultant.ClinicId);

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
                    Message = "Clinic is not active, cannot remove online consultation.",
                    Data = false
                };
            }

            _onlineConsultationRepository.SoftRemove(onlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove online consultation successfully" : "Remove online consultation fail",
                Data = result > 0
            };
        }

        public async Task<Result<ViewOnlineConsultationDTO>> UpdateOnlineConsultation(UpdateOnlineConsultationDTO onlineConsultation)
        {
            var onlineConsultationObj = await _onlineConsultationRepository
                .GetOnlineConsultationByOnlineConsultationIdAsync(onlineConsultation.Id);

            if (onlineConsultationObj is null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = null
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(onlineConsultationObj.ConsultantId);

            if (consultant == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot update online consultation.",
                    Data = null
                };
            }

            onlineConsultationObj.Trimester = onlineConsultation.Trimester;
            onlineConsultationObj.Date = onlineConsultation.Date;
            onlineConsultationObj.GestationalWeek = onlineConsultation.GestationalWeek;
            onlineConsultationObj.Summary = onlineConsultation.Summary;
            onlineConsultationObj.ConsultantNote = onlineConsultation.ConsultantNote;
            onlineConsultationObj.UserNote = onlineConsultation.UserNote;
            onlineConsultationObj.VitalSigns = onlineConsultation.VitalSigns;
            onlineConsultationObj.Recommendations = onlineConsultation.Recommendations;

            // --- Attachment synchronization logic ---
            var existingAttachments = onlineConsultationObj.Attachments ?? new List<Media>();
            var incomingAttachments = onlineConsultation.Attachments ?? new List<IFormFile>();

            if (incomingAttachments.Count > 4)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "You can upload a maximum of 4 attachments per consultation.",
                    Data = null
                };
            }

            var incomingFileNames = new HashSet<string>(
                incomingAttachments.Select(f => f.FileName),
                StringComparer.OrdinalIgnoreCase
            );

            var existingFileNames = new HashSet<string>(
                existingAttachments.Select(m => m.FileName),
                StringComparer.OrdinalIgnoreCase
            );

            // Delete attachments that are not in the incoming list
            foreach (var existingMedia in existingAttachments.ToList())
            {
                if (!incomingFileNames.Contains(existingMedia.FileName))
                {
                    if (!string.IsNullOrEmpty(existingMedia.FilePublicId))
                    {
                        await _cloudinaryService.DeleteFileAsync(existingMedia.FilePublicId);
                    }
                    onlineConsultationObj.Attachments.Remove(existingMedia);
                }
                // If filename is present in both, keep it (do nothing)
            }

            // Add new attachments that are not already present
            foreach (var attachment in incomingAttachments)
            {
                if (!existingFileNames.Contains(attachment.FileName))
                {
                    var response = await _cloudinaryService.UploadOnlineConsultationAttachment(
                        attachment.FileName, attachment, onlineConsultationObj);

                    if (response != null)
                    {
                        onlineConsultationObj.Attachments.Add(new Media
                        {
                            OnlineConsultationId = onlineConsultationObj.Id,
                            FileName = attachment.FileName,
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = attachment.ContentType
                        });
                    }
                }
                // If filename is present in both, keep it (do nothing)
            }
            // --- End attachment synchronization logic ---

            _onlineConsultationRepository.Update(onlineConsultationObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update online consultation successfully" : "Update online consultation fail",
                Data = _mapper.Map<ViewOnlineConsultationDTO>(onlineConsultationObj)
            };
        }
    }
}
