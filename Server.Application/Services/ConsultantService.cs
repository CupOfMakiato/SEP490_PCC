using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultant;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System.Security.Cryptography;

namespace Server.Application.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IEmailService _emailService;

        public ConsultantService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IConsultantRepository consultantRepository,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _consultantRepository = consultantRepository;
            _emailService = emailService;
        }

        public async Task<Result<ViewConsultantDTO>> CreateConsultant(AddConsultantDTO consultant)
        {
            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Clinic not found, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot create consultant",
                    Data = null
                };
            }

            if (await _unitOfWork.UserRepository.ExistsAsync(u => u.Email == consultant.Email))
            {
                throw new Exception("User with this email or phone number already exists.");
            }

            var otp = GenerateOtp();

            var user = new User
            {
                UserName = consultant.UserName,
                Email = consultant.Email,
                Password = HashPassword(consultant.PasswordHash),
                Balance = 0,
                PhoneNumber = consultant.PhoneNumber,
                Otp = otp,
                IsStaff = false,
                RoleId = 6, // Assuming 6 is the role ID for consultants
                CreationDate = DateTime.Now,
                OtpExpiryTime = DateTime.UtcNow.AddMinutes(10)
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            await _emailService.SendOtpEmailAsync(user.Email, otp);

            var consultantMapper = _mapper.Map<Consultant>(consultant);

            consultantMapper.UserId = user.Id;

            consultantMapper.ClinicId = clinic.Id;

            await _consultantRepository.AddAsync(consultantMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewConsultantDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new consultant successfully" : "Add new consultant fail",
                Data = null
            };
        }

        public async Task<Result<ViewConsultantDTO>> GetConsultantByIdAsync(Guid consultantId)
        {
            var consultant = await _consultantRepository.GetConsultantByIdAsync(consultantId);

            if (consultant == null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewConsultantDTO>(consultant);

            return new Result<ViewConsultantDTO>
            {
                Error = 0,
                Message = "Get consultant successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteConsultant(Guid consultantId)
        {
            var consultant = await _consultantRepository.GetConsultantByConsultantIdAsync(consultantId);

            if (consultant == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(consultant.ClinicId);

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
                    Message = "Clinic is not active, cannot remove consultant",
                    Data = false
                };
            }

            _consultantRepository.SoftRemove(consultant);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove consultant successfully" : "Remove consultant fail",
                Data = result > 0
            };
        }

        public async Task<Result<ViewConsultantDTO>> UpdateConsultant(UpdateConsultantDTO consultant)
        {
            var consultantObj = await _consultantRepository.GetConsultantByConsultantIdAsync(consultant.Id);

            if (consultantObj is null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(consultantObj.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot update consultant",
                    Data = null
                };
            }

            _mapper.Map(consultant, consultantObj);

            _unitOfWork.ConsultantRepository.Update(consultantObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewConsultantDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update consultant successfully" : "Update consultant fail",
                Data = null
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

        public async Task<Result<ViewConsultantDTO>> GetConsultantByUserIdAsync(Guid userId)
        {
            var consultant = await _consultantRepository.GetConsultantByUserIdAsync(userId);

            if (consultant == null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewConsultantDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewConsultantDTO>(consultant);

            return new Result<ViewConsultantDTO>
            {
                Error = 0,
                Message = "Get consultant successfully",
                Data = result
            };
        }
    }
}
