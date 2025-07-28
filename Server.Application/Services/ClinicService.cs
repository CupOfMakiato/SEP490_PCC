using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Clinic;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClinicRepository _clinicRepository;
        private readonly ICloudinaryService _cloudinaryService;

        public ClinicService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClinicRepository clinicRepository,
            ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clinicRepository = clinicRepository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Result<bool>> ApproveClinic(Guid clinicId)
        {
            var clinic = await _clinicRepository.GetClinicToApproveAsync(clinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            clinic.IsActive = true;

            _clinicRepository.Update(clinic);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Approve clinic successfully" : "Approve clinic fail",
                Data = true
            };
        }

        public async Task<Result<ViewClinicDTO>> CreateClinic(AddClinicDTO clinic)
        {
            var clinicMapper = new Clinic
            {
                Id = Guid.NewGuid(),
                Name = clinic.Name,
                Address = clinic.Address,
                Description = clinic.Description,
                Phone = clinic.Phone,
                Email = clinic.Email,
                IsInsuranceAccepted = clinic.IsInsuranceAccepted,
                IsActive = false, // Default to not approved when created
                Specializations = clinic.Specializations
            };

            await _clinicRepository.AddAsync(clinicMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            if (result <= 0)
            {
                return new Result<ViewClinicDTO>
                {
                    Error = 1,
                    Message = "Add new clinic fail",
                    Data = null
                };
            }

            if (clinic.ImageUrl != null && clinic.ImageUrl.Length > 0)
            {
                var imageResponse = await _cloudinaryService.UploadClinicImage(
                    clinic.ImageUrl.FileName,
                    clinic.ImageUrl,
                    clinicMapper
                );

                if (imageResponse != null)
                {
                    var media = new Media
                    {
                        ClinicId = clinicMapper.Id,
                        FileName = clinic.ImageUrl.FileName,
                        FileUrl = imageResponse.FileUrl,
                        FileType = clinic.ImageUrl.ContentType,
                        FilePublicId = imageResponse.PublicFileId
                    };

                    await _unitOfWork.MediaRepository.AddAsync(media);

                    var mediaResult = await _unitOfWork.SaveChangeAsync();

                    if (mediaResult > 0)
                    {
                        clinicMapper.ImageUrl = media;
                    }
                }
            }

            return new Result<ViewClinicDTO>
            {
                Error = 0,
                Message = "Add new clinic successfully",
                Data = _mapper.Map<ViewClinicDTO>(clinicMapper)
            };
        }

        public async Task<Result<ViewClinicDTO>> GetClinicByIdAsync(Guid clinicId)
        {
            var result = _mapper.Map<ViewClinicDTO>(await _clinicRepository.GetClinicByIdAsync(clinicId));

            return new Result<ViewClinicDTO>
            {
                Error = 0,
                Message = "View clinic successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewClinicDTO>>> GetClinicByNameAsync(string name)
        {
            var result = _mapper.Map<List<ViewClinicDTO>>(await _clinicRepository.GetClinicByNameAsync(name));

            return new Result<List<ViewClinicDTO>>
            {
                Error = 0,
                Message = "View clinic by name successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewClinicDTO>>> GetClinicsAsync()
        {
            var result = _mapper.Map<List<ViewClinicDTO>>(await _clinicRepository.GetClinicsAsync());

            return new Result<List<ViewClinicDTO>>
            {
                Error = 0,
                Message = "View all clinics successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> RejectClinic(Guid clinicId)
        {
            var clinic = await _clinicRepository.GetClinicToApproveAsync(clinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            clinic.IsActive = false;

            _clinicRepository.Update(clinic);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Reject clinic successfully" : "Reject clinic fail",
                Data = true
            };
        }

        public async Task<Result<bool>> SoftDeleteClinic(Guid clinicId)
        {
            var clinic = await _clinicRepository.GetClinicByIdAsync(clinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            _clinicRepository.SoftRemove(clinic);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove clinic successfully" : "Remove clinic fail",
                Data = true
            };
        }

        public async Task<Result<ViewClinicDTO>> UpdateClinic(UpdateClinicDTO clinic)
        {
            var clinicObj = await _clinicRepository.GetClinicByClinicIdAsync(clinic.Id);

            if (clinicObj is null)
            {
                return new Result<ViewClinicDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinicObj.IsActive)
            {
                return new Result<ViewClinicDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot update",
                    Data = null
                };
            }

            clinicObj.Name = clinic.Name;
            clinicObj.Address = clinic.Address;
            clinicObj.Description = clinic.Description;
            clinicObj.Phone = clinic.Phone;
            clinicObj.Email = clinic.Email;
            clinicObj.IsInsuranceAccepted = clinic.IsInsuranceAccepted;
            clinicObj.Specializations = clinic.Specializations;

            if (clinic.ImageUrl != null && clinic.ImageUrl.Length > 0)
            {
                if (clinicObj.ImageUrl != null && !string.IsNullOrEmpty(clinicObj.ImageUrl.FilePublicId))
                {
                    var deleteResult = await _cloudinaryService.DeleteFileAsync(clinicObj.ImageUrl.FilePublicId);

                    if (deleteResult == null || deleteResult.Result != "ok")
                    {
                        return new Result<ViewClinicDTO>
                        {
                            Error = 1,
                            Message = "Failed to delete old image from Cloudinary."
                        };
                    }
                }

                var imageResponse = await _cloudinaryService.UploadClinicImage(
                    clinic.ImageUrl.FileName,
                    clinic.ImageUrl,
                    clinicObj
                );

                if (imageResponse != null)
                {
                    if (clinicObj.ImageUrl != null)
                    {
                        clinicObj.ImageUrl.FileName = clinic.ImageUrl.FileName;
                        clinicObj.ImageUrl.FileUrl = imageResponse.FileUrl;
                        clinicObj.ImageUrl.FileType = clinic.ImageUrl.ContentType;
                        clinicObj.ImageUrl.FilePublicId = imageResponse.PublicFileId;

                        _unitOfWork.MediaRepository.Update(clinicObj.ImageUrl);

                        await _unitOfWork.SaveChangeAsync();
                    }
                }
            }

            _clinicRepository.Update(clinicObj);

            var result = _unitOfWork.SaveChangeAsync().Result;

            return new Result<ViewClinicDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update clinic successfully" : "Update clinic fail",
                Data = _mapper.Map<ViewClinicDTO>(clinicObj)
            };
        }
    }
}
