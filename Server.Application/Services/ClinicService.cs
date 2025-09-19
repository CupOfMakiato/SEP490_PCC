using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Clinic;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Server.Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClinicRepository _clinicRepository;
        private readonly IEmailService _emailService;

        public ClinicService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClinicRepository clinicRepository,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clinicRepository = clinicRepository;
            _emailService = emailService;
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
                Data = result > 0
            };
        }

        public async Task<Result<ViewClinicDTO>> CreateClinic(AddClinicDTO clinic)
        {
            var otp = GenerateOtp();

            var user = new User
            {
                UserName = clinic.UserName,
                Email = clinic.Email,
                Password = HashPassword(clinic.PasswordHash),
                Balance = 0,
                PhoneNumber = clinic.PhoneNumber,
                Otp = otp,
                IsStaff = false,
                RoleId = 5, // Assuming 5 is the role ID for clinics
                CreationDate = DateTime.Now,
                OtpExpiryTime = DateTime.UtcNow.AddMinutes(10)
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            await _emailService.SendOtpEmailAsync(user.Email, otp);

            var clinicMapper = _mapper.Map<Clinic>(clinic);

            clinicMapper.UserId = user.Id;

            clinicMapper.IsActive = false; // Initially set to false until approved

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
                Data = result > 0
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
                Data = result > 0
            };
        }

        public async Task<Result<List<ViewClinicDTO>>> SuggestClinicsAsync(Guid userId)
        {
            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(userId);

            if (user == null || string.IsNullOrEmpty(user.Address))
            {
                return new Result<List<ViewClinicDTO>>
                {
                    Error = 1,
                    Message = "User not found or address is missing",
                    Data = null
                };
            }

            var clinics = await _clinicRepository
                .SuggestClinicsAsync(user.Address);

            return new Result<List<ViewClinicDTO>>
            {
                Error = 0,
                Message = "Suggested clinics retrieved successfully",
                Data = _mapper.Map<List<ViewClinicDTO>>(clinics)
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

            clinicObj.Address = clinic.Address;
            clinicObj.Description = clinic.Description;
            clinicObj.IsInsuranceAccepted = clinic.IsInsuranceAccepted;
            clinicObj.Specializations = clinic.Specializations;

            _clinicRepository.Update(clinicObj);

            var result = _unitOfWork.SaveChangeAsync().Result;

            return new Result<ViewClinicDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update clinic successfully" : "Update clinic fail",
                Data = _mapper.Map<ViewClinicDTO>(clinicObj)
            };
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private string GenerateOtp()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var byteArray = new byte[4];
                rng.GetBytes(byteArray);
                var otp = BitConverter.ToUInt32(byteArray, 0) % 1000000; // Generate a 6-digit OTP
                return otp.ToString("D6");
            }
        }

        public async Task<Result<ViewClinicDTO>> GetClinicByUserIdAsync(Guid userId)
        {
            var result = _mapper.Map<ViewClinicDTO>(await _clinicRepository.GetClinicByUserId(userId));

            return new Result<ViewClinicDTO>
            {
                Error = 0,
                Message = "View clinic by user id successfully",
                Data = result
            };
        }
    }
}
