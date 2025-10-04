using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Application.Utils;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;
        private readonly IEmailService _emailService;
        private readonly TokenGenerators _tokenGenerators;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRedisService _redisService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IConfiguration configuration,
            IAuthRepository authRepository, IEmailService emailService, IRedisService redisService,
            TokenGenerators tokenGenerators, IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository, IClaimsService claimsService, IUnitOfWork unitOfWork,
            ICloudinaryService cloudinaryService, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _authRepository = authRepository;
            _emailService = emailService;
            _tokenGenerators = tokenGenerators;
            _httpContextAccessor = httpContextAccessor;
            _redisService = redisService;
            _categoryRepository = categoryRepository;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
        }

        public async Task<IList<User>> GetALl()
        {
            var getUser = await _userRepository.GetAllAsync();
            return getUser;
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<Result<GetUserDTO>> ViewUserById(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id);
            var result = _mapper.Map<GetUserDTO>(user);
            return new Result<GetUserDTO>
            {
                Error = 0,
                Message = "View user by id successfully",
                Data = result
            };
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task<Result<UserDTO>> GetCurrentUserById()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
                return new Result<UserDTO>() { Error = 1, Message = "Token not found", Data = null };

            var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                return new Result<UserDTO>() { Error = 1, Message = "Invalid token", Data = null };
            var userId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "id").Value);
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
                return new Result<UserDTO>() { Error = 1, Message = "User not found", Data = null };

            // This should return success when user is found
            var userDto = _mapper.Map<UserDTO>(user);
            return new Result<UserDTO>
            {
                Error = 0,
                Message = "Success",
                Data = userDto
            };
        }

        public async Task<User> HardDeleteUser(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _userRepository.HardRemove(user);
            return user;

        }
        public async Task<Result<object>> UploadAvatar(Guid userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new Result<object> { Error = 1, Message = "No file selected." };
            }

            const long maxFileSize = 5 * 1024 * 1024; // 5MB
            if (file.Length > maxFileSize)
            {
                return new Result<object> { Error = 1, Message = "File size exceeds 5MB." };
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Invalid file type. Only JPG, PNG, and GIF are allowed."
                };
            }

            var user = await _unitOfWork.UserRepository.GetUserById(userId);
            if (user == null)
            {
                return new Result<object> { Error = 1, Message = "User not found." };
            }

            if (user.Avatar != null)
            {
                var deleteResult = await _cloudinaryService.DeleteFileAsync(user.Avatar.FilePublicId);
                if (deleteResult == null || deleteResult.Result != "ok")
                {
                    return new Result<object>
                    {
                        Error = 1,
                        Message = "Failed to delete old avatar from Cloudinary."
                    };
                }
            }

            var uploadResult = await _cloudinaryService.UploadAvatarImage(file.FileName, file, user);
            if (uploadResult == null || string.IsNullOrEmpty(uploadResult.FileUrl))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Failed to upload avatar to Cloudinary."
                };
            }

            var newAvatar = new Media
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FileUrl = uploadResult.FileUrl,
                FileType = file.ContentType,
                FilePublicId = uploadResult.PublicFileId,
                CreatedBy = userId,
                CreationDate = DateTime.Today,
                UserId = user.Id
            };

            await _unitOfWork.MediaRepository.AddAsync(newAvatar);

            user.Avatar = newAvatar;

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Avatar uploaded successfully." : "Failed to upload avatar.",
                Data = new
                {
                    FileUrl = uploadResult.FileUrl,
                    PublicId = uploadResult.PublicFileId
                }
            };
        }
        public async Task<Result<object>> EditUserProfile(EditUserDTO EditUserDTO)
        {
            var user = await _userRepository.GetUserById(EditUserDTO.Id);
            if (user == null)
            {
                return new Result<object> 
                { 
                    Error = 1, 
                    Message = "User not found." 
                };
            }
            user.UserName = EditUserDTO.UserName ?? user.UserName;
            user.PhoneNumber = EditUserDTO.PhoneNumber ?? user.PhoneNumber;
            user.DateOfBirth = EditUserDTO?.DateOfBirth ?? user.DateOfBirth;

            _unitOfWork.UserRepository.Update(user);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result > 0)
                return new Result<object>
                {
                    Error = 0,
                    Data = new
                    {
                        user.UserName,
                        user.PhoneNumber,
                        user.DateOfBirth
                    }
                };
            return new Result<object>
            {
                Error = 1,
                Message = "Failed to edit user profile.",
            };
        }

        public async Task<Result<UserDiseasesAndUserAllergiesDTO>> GetAllergyAndDiseaseByUserId(Guid userId)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<UserDiseasesAndUserAllergiesDTO>
                {
                    Error = 1,
                    Message = "User not found",
                    Data = null
                };
            }
            var result = new UserDiseasesAndUserAllergiesDTO
            {
                Diseases = user.UserDiseases.Select(ud => new UserDiseasesDTO
                {
                    DiseaseId = ud.DiseaseId,
                    DiagnosedAt = ud.DiagnosedAt,
                    IsBeforePregnancy = ud.IsBeforePregnancy,
                    ExpectedCuredAt = ud.ExpectedCuredAt,
                    ActualCuredAt = ud.ActualCuredAt,
                    DiseaseType = ud.DiseaseType,
                    IsCured = ud.IsCured
                }).ToList(),
                Allergies = user.UserAllergy.Select(ua => new UserAllergiesDTO
                {
                    AllergyId = ua.AllergyId,
                    Severity = ua.Severity,
                    Notes = ua.Notes,
                    DiagnosedAt = ua.DiagnosedAt,
                    IsActive = ua.IsActive
                }).ToList()
            };
            return new Result<UserDiseasesAndUserAllergiesDTO>
            {
                Error = 0,
                Message = "Get allergies and diseases successfully",
                Data = result
            };
        }

        public async Task<Result<object>> AddDiseaseToUser(Guid userId, UserDiseasesDTO diseasesDTO)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User not found"
                };
            }
            var existingDisease = user.UserDiseases.FirstOrDefault(ud => ud.DiseaseId == diseasesDTO.DiseaseId);
            if (existingDisease != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Disease already exists for this user"
                };
            }
            var disease = await _unitOfWork.DiseaseRepository.GetByIdAsync(diseasesDTO.DiseaseId);
            if (disease == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Disease not found"
                };
            }
            var newUserDisease = new UserDisease
            {
                UserId = userId,
                DiseaseId = diseasesDTO.DiseaseId,
                DiagnosedAt = diseasesDTO.DiagnosedAt,
                IsBeforePregnancy = diseasesDTO.IsBeforePregnancy,
                ExpectedCuredAt = diseasesDTO.ExpectedCuredAt,
                ActualCuredAt = diseasesDTO.ActualCuredAt,
                DiseaseType = diseasesDTO.DiseaseType,
                IsCured = diseasesDTO.IsCured,
                CreateAt = DateTime.UtcNow,
                Disease = disease
            };
            user.UserDiseases.Add(newUserDisease);
            _userRepository.Update(user);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<object>
                {
                    Error = 0,
                    Message = "Disease added to user successfully",
                    Data = newUserDisease
                };
            }
            return new Result<object>
            {
                Error = 1,
                Message = "Failed to add disease to user"
            };
        }

        public async Task<Result<object>> AddAlleryToUser(Guid userId, UserAllergiesDTO allergiesDTO)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User not found"
                };
            }
            var existingAllergy = user.UserAllergy.FirstOrDefault(ua => ua.AllergyId == allergiesDTO.AllergyId);
            if (existingAllergy != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Allergy already exists for this user"
                };
            }
            var allergy = await _unitOfWork.AllergyRepository.GetByIdAsync(allergiesDTO.AllergyId);
            if (allergy == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Allergy not found"
                };
            }
            var newUserAllergy = new UserAllergy
            {
                UserId = userId,
                AllergyId = allergiesDTO.AllergyId,
                Severity = allergiesDTO.Severity,
                Notes = allergiesDTO.Notes,
                DiagnosedAt = allergiesDTO.DiagnosedAt,
                IsActive = allergiesDTO.IsActive,
                Allergy = allergy
            };
            user.UserAllergy.Add(newUserAllergy);
            _userRepository.Update(user);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<object>
                {
                    Error = 0,
                    Message = "Allergy added to user successfully",
                    Data = newUserAllergy
                };
            }
            return new Result<object>
            {
                Error = 1,
                Message = "Failed to add allergy to user"
            };
        }

        public async Task<Result<bool>> RemoveDiseaseFromUser(Guid userId, Guid diseaseId)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "User not found",
                    Data = false
                };
            }
            var userDisease = user.UserDiseases.FirstOrDefault(ud => ud.DiseaseId == diseaseId);
            if (userDisease == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Disease not found for this user",
                    Data = false
                };
            }
            user.UserDiseases.Remove(userDisease);
            _userRepository.Update(user);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>
                {
                    Error = 0,
                    Message = "Disease removed from user successfully",
                    Data = true
                };
            }
            return new Result<bool>
            {
                Error = 1,
                Message = "Failed to remove disease from user",
                Data = false
            };
        }

        public async Task<Result<bool>> RemoveAllergyFromUser(Guid userId, Guid allergyId)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "User not found",
                    Data = false
                };
            }
            var userAllergy = user.UserAllergy.FirstOrDefault(ua => ua.AllergyId == allergyId);
            if (userAllergy == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Allergy not found for this user",
                    Data = false
                };
            }
            user.UserAllergy.Remove(userAllergy);
            _userRepository.Update(user);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>
                {
                    Error = 0,
                    Message = "Allergy removed from user successfully",
                    Data = true
                };
            }
            return new Result<bool>
            {
                Error = 1,
                Message = "Failed to remove allergy from user",
                Data = false
            };
        }

        public async Task<Result<object>> UpdateDiseaseToUser(Guid userId, UserDiseasesDTO diseasesDTO)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User not found"
                };
            }
            var userDisease = user.UserDiseases.FirstOrDefault(ud => ud.DiseaseId == diseasesDTO.DiseaseId);
            if (userDisease == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Disease not found for this user"
                };
            }
            userDisease.DiagnosedAt = diseasesDTO.DiagnosedAt ?? userDisease.DiagnosedAt;
            userDisease.IsBeforePregnancy = diseasesDTO.IsBeforePregnancy;
            userDisease.ExpectedCuredAt = diseasesDTO.ExpectedCuredAt ??userDisease.ExpectedCuredAt;
            userDisease.ActualCuredAt = diseasesDTO.ActualCuredAt ?? userDisease.ActualCuredAt;
            userDisease.DiseaseType = diseasesDTO.DiseaseType;
            userDisease.IsCured = diseasesDTO.IsCured ?? userDisease.IsCured;
            _userRepository.Update(user);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<object>
                {
                    Error = 0,
                    Message = "Disease updated successfully",
                    Data = userDisease
                };
            }
            return new Result<object>
            {
                Error = 1,
                Message = "Failed to update disease",
            };
        }

        public async Task<Result<object>> UpdateAlleryToUser(Guid userId, UserAllergiesDTO allergiesDTO)
        {
            var user = await _userRepository.GetUserWithAllergyAndDisease(userId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User not found"
                };
            }
            var userAllergy = user.UserAllergy.FirstOrDefault(ua => ua.AllergyId == allergiesDTO.AllergyId);
            if (userAllergy == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Allergy not found for this user"
                };
            }
            userAllergy.Severity = allergiesDTO.Severity ?? userAllergy.Severity;
            userAllergy.Notes = allergiesDTO.Notes ?? userAllergy.Notes;
            userAllergy.DiagnosedAt = allergiesDTO.DiagnosedAt;
            userAllergy.IsActive = allergiesDTO.IsActive;
            _userRepository.Update(user);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<object>
                {
                    Error = 0,
                    Message = "Allergy updated successfully",
                    Data = userAllergy
                };
            }
            return new Result<object>
            {
                Error = 1,
                Message = "Failed to update allergy",
            };
        }
    }
}
