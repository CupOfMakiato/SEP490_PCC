using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly ICloudinaryService _cloudinaryService;

        public OnlineConsultationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOnlineConsultationRepository onlineConsultationRepository,
            ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _onlineConsultationRepository = onlineConsultationRepository;
            _cloudinaryService = cloudinaryService;
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
                Message = result > 0 ? "Remove online consultation successfully" : "Remove clinic fail",
                Data = true
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
                    Message = "Clinic is not active, cannot remove online consultation.",
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

            // Synchronize attachments
            var existingAttachments = onlineConsultationObj.Attachments ?? new List<Media>();

            var newFiles = onlineConsultation.Attachments ?? new List<IFormFile>();

            // Remove attachments not present in the new list (by filename)
            var newFileNames = newFiles.Select(f => f.FileName).ToHashSet(StringComparer.OrdinalIgnoreCase);

            var toRemove = existingAttachments.Where(m => !newFileNames.Contains(m.FileName)).ToList();

            foreach (var media in toRemove)
            {
                // Delete from Cloudinary
                if (!string.IsNullOrEmpty(media.FilePublicId))
                {
                    var deleteResult = await _cloudinaryService.DeleteFileAsync(media.FilePublicId);

                    if (deleteResult == null || deleteResult.Result != "ok")
                    {
                        return new Result<ViewOnlineConsultationDTO>
                        {
                            Error = 1,
                            Message = "Failed to delete old attachment from Cloudinary."
                        };
                    }
                }
                // Mark as deleted in DB (or remove)
                media.IsDeleted = true;

                _unitOfWork.MediaRepository.Update(media);

                onlineConsultationObj.Attachments.Remove(media);
            }
            await _unitOfWork.SaveChangeAsync();

            // Add new files not already present
            var existingFileNames = existingAttachments.Where(m => !m.IsDeleted).Select(m => m.FileName).ToHashSet(StringComparer.OrdinalIgnoreCase);
            foreach (var file in newFiles)
            {
                if (!existingFileNames.Contains(file.FileName))
                {
                    var response = await _cloudinaryService.UploadOnlineConsultationAttachment(
                        file.FileName, file, onlineConsultationObj);

                    if (response != null)
                    {
                        var media = new Media
                        {
                            OnlineConsultationId = onlineConsultationObj.Id,
                            FileName = file.FileName,
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = file.ContentType
                        };
                        await _unitOfWork.MediaRepository.AddAsync(media);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                            onlineConsultationObj.Attachments.Add(media);
                    }
                }
            }

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
