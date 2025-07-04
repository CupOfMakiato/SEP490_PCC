using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Admin;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Application.Utils;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly TokenGenerators _tokenGenerators;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IOtpService _otpService;
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IAuthRepository authRepository, TokenGenerators tokenGenerators,
            IUserRepository userRepository, IHttpContextAccessor httpContextAccessor,
            IEmailService emailService, IConfiguration configuration, IOtpService otpService,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authRepository = authRepository;
            _tokenGenerators = tokenGenerators;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _configuration = configuration;
            _otpService = otpService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetUserDTO>>> ViewAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetALl();

            var result = _mapper.Map<List<GetUserDTO>>(users);



            return new Result<List<GetUserDTO>>
            {
                Error = 0,
                Message = "View all users successfully",
                Data = result
            };
        }

        public async Task<Result<List<GetUserDTO>>> ViewAllStaff()
        {
            var users = await _unitOfWork.UserRepository.GetAllStaff();

            var result = _mapper.Map<List<GetUserDTO>>(users);



            return new Result<List<GetUserDTO>>
            {
                Error = 0,
                Message = "View all staffs successfully",
                Data = result
            };
        }
        public async Task<Result<List<GetUserDTO>>> ViewAllClinics()
        {
            var clinics = await _unitOfWork.UserRepository.GetAllClinic();
            var result = _mapper.Map<List<GetUserDTO>>(clinics);



            return new Result<List<GetUserDTO>>
            {
                Error = 0,
                Message = "View all clinics successfully",
                Data = result
            };
        }
        public async Task<Result<object>> CreateHealthExpertAccount(CreateAccountDTO CreateAccountDTO)
        {
            var existingUserByEmail = await _unitOfWork.UserRepository.GetUserByEmail(CreateAccountDTO.Email);
            if (existingUserByEmail != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Email is already in use.",
                    Data = null
                };
            }

            // Check if the username already exists
            var existingUserByUsername = await _unitOfWork.UserRepository.GetUserByName(CreateAccountDTO.UserName);
            if (existingUserByUsername != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Username is already exist.",
                    Data = null
                };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(CreateAccountDTO.PasswordHash);

            // Create user entity
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = CreateAccountDTO.UserName,
                Email = CreateAccountDTO.Email,
                PhoneNumber = CreateAccountDTO.PhoneNumber,
                Password = hashedPassword,
                Status = StatusEnums.Active,
                IsVerified = true,
                RoleId = 3, // HealthExpert
                CreationDate = DateTime.Now.Date,
                IsDeleted = false
            };

            await _unitOfWork.UserRepository.AddUser(user);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Health Expert account created successfully." : "Failed to create account.",
                Data = null
            };
        }
        public async Task<Result<object>> CreateNutrientSpecialistAccount(CreateAccountDTO CreateAccountDTO)
        {
            var existingUserByEmail = await _unitOfWork.UserRepository.GetUserByEmail(CreateAccountDTO.Email);
            if (existingUserByEmail != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Email is already in use.",
                    Data = null
                };
            }

            // Check if the username already exists
            var existingUserByUsername = await _unitOfWork.UserRepository.GetUserByName(CreateAccountDTO.UserName);
            if (existingUserByUsername != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Username is already exist.",
                    Data = null
                };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(CreateAccountDTO.PasswordHash);

            // Create user entity
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = CreateAccountDTO.UserName,
                Email = CreateAccountDTO.Email,
                PhoneNumber = CreateAccountDTO.PhoneNumber,
                Password = hashedPassword,
                Status = StatusEnums.Active,
                IsVerified = true,
                RoleId = 4, // NutrientSpecialist
                CreationDate = DateTime.Now.Date,
                IsDeleted = false
            };

            await _unitOfWork.UserRepository.AddUser(user);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Nutrient Specialist account created successfully." : "Failed to create account.",
                Data = null
            };
        }
        public async Task<Result<object>> CreateClinicAccount(CreateAccountDTO CreateAccountDTO)
        {
            var existingUserByEmail = await _unitOfWork.UserRepository.GetUserByEmail(CreateAccountDTO.Email);
            if (existingUserByEmail != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Email is already in use.",
                    Data = null
                };
            }

            // Check if the username already exists
            var existingUserByUsername = await _unitOfWork.UserRepository.GetUserByName(CreateAccountDTO.UserName);
            if (existingUserByUsername != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Username is already exist.",
                    Data = null
                };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(CreateAccountDTO.PasswordHash);

            // Create user entity
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = CreateAccountDTO.UserName,
                Email = CreateAccountDTO.Email,
                PhoneNumber = CreateAccountDTO.PhoneNumber,
                Password = hashedPassword,
                Status = StatusEnums.Active,
                IsVerified = true,
                RoleId = 5, // Clinic
                CreationDate = DateTime.Now.Date,
                IsDeleted = false
            };

            await _unitOfWork.UserRepository.AddUser(user);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Clinic account created successfully." : "Failed to create account.",
                Data = null
            };
        }
        public async Task<Result<object>> ChangeAccountAuthorize(EditAccountDTO EditAccountDTO)
        {
            var existingAccount = await _unitOfWork.UserRepository.FindByEmail(EditAccountDTO.Email);
            if (existingAccount == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Account not found.",
                    Data = null
                };
            }
            // Update account details
            existingAccount.RoleId = EditAccountDTO.RoleId;

            if (EditAccountDTO.RoleId == 1)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Cannot change role to Admin!",
                    Data = null
                };
            }
            _unitOfWork.UserRepository.Update(existingAccount);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result <= 0)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Failed to update account.",
                    Data = null
                };
            }
            return new Result<object>
            {
                Error = 0,
                Message = $"Account updated successfully!",
                Data = null
            };
        }
        public async Task HardDeleteAccount(string email)
        {
            var exisitingAccount = await _unitOfWork.UserRepository.FindByEmail(email);
            if (exisitingAccount == null)
            {
                throw new Exception("Account not found.");
            }
            // Hard delete the account
            _unitOfWork.UserRepository.HardRemove(exisitingAccount);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result <= 0)
            {
                throw new Exception("Failed to delete account.");
            }
        }
        public async Task<Result<object>> BanAccount(string email)
        {
            var exisitingAccount = await _unitOfWork.UserRepository.FindByEmail(email);
            if (exisitingAccount == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Account not found.",
                    Data = null
                };
            }
            if (exisitingAccount.Status == StatusEnums.Inactive)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Account is already banned.",
                    Data = null
                };
            }
            // Ban the account
            exisitingAccount.Status = StatusEnums.Inactive;
            _unitOfWork.UserRepository.Update(exisitingAccount);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result <= 0)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Failed to ban account.",
                    Data = null
                };
            }
            return new Result<object>
            {
                Error = 0,
                Message = "Account banned successfully.",
                Data = null
            };
        }
        public async Task<Result<object>> UnBanAccount(string email)
        {
            var exisitingAccount = await _unitOfWork.UserRepository.FindByEmail(email);
            if (exisitingAccount == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Account not found.",
                    Data = null
                };
            }
            if (exisitingAccount.Status == StatusEnums.Active)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Account is already active.",
                    Data = null
                };
            }
            // Ban the account
            exisitingAccount.Status = StatusEnums.Active;
            _unitOfWork.UserRepository.Update(exisitingAccount);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result <= 0)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Failed to unban account.",
                    Data = null
                };
            }
            return new Result<object>
            {
                Error = 0,
                Message = "Account unbanned successfully.",
                Data = null
            };
        }
    }
}
