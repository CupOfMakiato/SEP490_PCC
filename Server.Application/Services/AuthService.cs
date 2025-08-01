﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Google.Apis.Auth;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Application.DTOs.Auth;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Application.Utils;
using Server.Domain.Entities;
using Server.Domain.Enums;
using static System.Net.WebRequestMethods;

namespace Server.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly TokenGenerators _tokenGenerators;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IOtpService _otpService;
        private readonly IRedisService _redisService;

        public AuthService(IAuthRepository authRepository, TokenGenerators tokenGenerators,
            IUserRepository userRepository, IHttpContextAccessor httpContextAccessor,
            IEmailService emailService, IConfiguration configuration, IOtpService otpService,
            IMapper mapper, IRedisService redisService)
        {
            _authRepository = authRepository;
            _tokenGenerators = tokenGenerators;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _configuration = configuration;
            _otpService = otpService;
            _mapper = mapper;
            _redisService = redisService;
        }

        public async Task<Authenticator> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(loginDTO.Email);

                if (user == null)
                {
                    throw new KeyNotFoundException("Invalid email or account does not exist.");
                }

                if (!user.IsVerified)
                {
                    throw new InvalidOperationException("Account is not activated. Please verify your email.");
                }
                if (user.Status.ToString() != "Active")
                {
                    throw new InvalidOperationException("Your account has been lock. Contact to website to solve it.");
                }
                if (!BCrypt.Net.BCrypt.Verify(loginDTO.PasswordHash, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid password.");
                }

                // Generate JWT token
                var token = await GenerateJwtToken(user);
                return token;
            }
            catch (KeyNotFoundException ex)
            {
                // Handle cases where the user is not found
                throw new ApplicationException("Invalid email or account does not exist.", ex);
            }
            catch (InvalidOperationException ex)
            {
                // Handle cases where the account is not verified
                throw new ApplicationException("Account is not activated. Please verify your email.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle cases where the password is invalid
                throw new ApplicationException("Invalid password.", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new ApplicationException("An error occurred during login.", ex);
            }
        }

        //Register User Account
        public async Task RegisterUserAsync(UserRegistrationDTO userRegistrationDto)
        {
            try
            {
                if (await _userRepository.ExistsAsync(u => u.Email == userRegistrationDto.Email))
                {
                    throw new Exception("User with this email or phone number already exists.");
                }

                var otp = GenerateOtp();
                var user = new User
                {
                    UserName = userRegistrationDto.UserName,
                    Email = userRegistrationDto.Email,
                    Password = HashPassword(userRegistrationDto.PasswordHash),
                    Balance = 0,
                    PhoneNumber = userRegistrationDto.PhoneNo ?? userRegistrationDto.PhoneNo,
                    Status = StatusEnums.Pending,
                    Otp = otp,
                    IsStaff = false,
                    RoleId = 2, 
                    CreationDate = DateTime.Now,
                    OtpExpiryTime = DateTime.UtcNow.AddMinutes(10)

                };

                await _userRepository.AddAsync(user);
                await _emailService.SendOtpEmailAsync(user.Email, otp);
            }
            catch (ArgumentNullException ex)
            {
                // Handle cases where required information is missing
                throw new ApplicationException("Missing required registration information.", ex);
            }
            catch (InvalidOperationException ex)
            {
                // Handle cases where an operation is invalid, such as duplicate user registration
                throw new ApplicationException("Invalid operation during user registration.", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new ApplicationException("An error occurred while registering the user.", ex);
            }
        }


        public async Task<User> GetByVerificationToken(string token)
        {
            try
            {
                return await _userRepository.GetUserByVerificationToken(token);
            }
            catch (Exception ex)
            {
                // Handle potential exceptions such as token not found
                throw new ApplicationException("An error occurred while retrieving the user by verification token.", ex);
            }
        }

        private async Task<Authenticator> GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()), // Ensuring UserId claim is added
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role?.RoleName),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(120), // Token expiration set to 120 minutes
            signingCredentials: creds
            );

            var refreshToken = Guid.NewGuid().ToString();
            await _authRepository.UpdateRefreshToken(user.Id, refreshToken);

            return new Authenticator
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken
            };
        }

        //logout

        public async Task<bool> DeleteRefreshToken(Guid userId)
        {
            return await _authRepository.DeleteRefreshToken(userId);
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

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                if (user.Otp != otp || user.OtpExpiryTime < DateTime.UtcNow)
                {
                    return false;
                }

                user.IsVerified = true;
                user.Otp = null;
                user.OtpExpiryTime = null;
                user.Status = StatusEnums.Active; // Update status to Active

                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch (KeyNotFoundException ex)
            {
                // Handle cases where the user is not found
                throw new ApplicationException("User not found for OTP verification.", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new ApplicationException("An error occurred while verifying the OTP.", ex);
            }
        }

        public async Task<bool> VerifyOtpAndCompleteRegistrationAsync(string email, string otp)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null || user.Otp != otp || user.OtpExpiryTime < DateTime.UtcNow)
            {
                return false;
            }

            user.IsVerified = true;
            user.Status = user.RoleId == 2 ? StatusEnums.Pending : StatusEnums.Active;
            user.Otp = "";
            user.OtpExpiryTime = null;

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> ResendOtp(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
                throw new KeyNotFoundException("User not found.");

            if (user.IsVerified)
                throw new InvalidOperationException("Account is already verified!");

            // Regenerate OTP
            var newOtp = GenerateOtp();
            user.Otp = newOtp;
            user.OtpExpiryTime = DateTime.UtcNow.AddMinutes(10);

            await _userRepository.UpdateAsync(user);

            await _emailService.ReSendOtpEmail(user.Email, newOtp);

            return true;
        }

        //PASSWORD
        public async Task ChangePasswordAsync(string email, ChangePasswordDTO changePasswordDto)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);

                if (user == null || !BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, user.Password))
                {
                    throw new ArgumentException("Invalid old password.");
                }

                if (changePasswordDto.NewPassword == changePasswordDto.OldPassword)
                {
                    throw new InvalidOperationException("New password cannot be the same as the old password.");
                }

                if (!ValidatePassword(changePasswordDto.NewPassword))
                {
                    throw new ArgumentException("New password must contain at least one uppercase letter and one special character.");
                }

                user.Password = HashPassword(changePasswordDto.NewPassword);
                await _userRepository.UpdateAsync(user);
            }
            catch (ArgumentException ex)
            {
                // Handle cases where the provided password details are invalid
                throw new ApplicationException("Password change failed due to invalid input.", ex);
            }
            catch (InvalidOperationException ex)
            {
                // Handle cases where the new password is the same as the old password
                throw new ApplicationException("Password change failed due to operational constraints.", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new ApplicationException("An error occurred while changing the password.", ex);
            }
        }
        public async Task<Authenticator> RefreshToken(string token)
        {
            //Check refreshToken have validate
            var checkRefreshToken = _tokenGenerators.ValidateRefreshToken(token);
            if (!checkRefreshToken)
                return null;
            //Check refreshToken in DB
            var user = await _authRepository.GetRefreshToken(token);
            if (user == null) return null;
            List<Claim> claims = new() {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Role.RoleName)
        };

            var (accessToken, refreshToken) = _tokenGenerators.GenerateTokens(claims);

            await _authRepository.UpdateRefreshToken(user.Id, refreshToken);
            return new Authenticator()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
        private bool ValidatePassword(string password)
        {
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool isValidLength = password.Length >= 6;

            return hasUpperCase && hasSpecialChar && isValidLength;
        }

        public async Task RequestPasswordResetAsync(ForgotPasswordRequestDTO forgotPasswordRequestDto)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(forgotPasswordRequestDto.EmailOrPhoneNumber);

                if (user == null || !user.IsVerified)
                {
                    throw new KeyNotFoundException("User not found or not activated.");
                }

                var token = GenerateResetToken();
                user.ResetToken = token;
                user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);

                await _userRepository.UpdateAsync(user);

                //var resetLink = $"{_configuration["AppSettings:FrontendUrl"]}/reset-password?token={token}"; -- FRONT-END ONLY

                await _emailService.SendEmailAsync(new EmailDTO
                {
                    To = user.Email,
                    Subject = "Password Reset Request",
                    //Body = $"Please reset your password by clicking on the following link: <a href='{resetLink}'>Reset Password</a>" -- FRONT-END ONLY

                    Body = @$"Your token for resetting password is: {token}"
                });
            }
            catch (KeyNotFoundException ex)
            {
                // Handle cases where the user is not found or not activated
                throw new ApplicationException("Password reset request failed due to user not found or not activated.", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new ApplicationException("An error occurred while requesting the password reset.", ex);
            }
        }
        public async Task ResetPasswordAsync(ResetPasswordDTO resetPasswordDto)
        {
            try
            {
                var user = await _userRepository.GetUserByResetToken(resetPasswordDto.Token);

                if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
                {
                    throw new ArgumentException("Invalid or expired token.");
                }

                if (!ValidatePassword(resetPasswordDto.NewPassword))
                {
                    throw new ArgumentException("New password must contain at least one uppercase letter, one special character, and be at least 6 characters long.");
                }

                user.Password = HashPassword(resetPasswordDto.NewPassword);
                user.ResetToken = null;
                user.ResetTokenExpiry = null;

                await _userRepository.UpdateAsync(user);
            }
            catch (ArgumentException ex)
            {
                // Handle cases where the token is invalid or the new password does not meet requirements
                throw new ApplicationException("Password reset failed due to invalid input.", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new ApplicationException("An error occurred while resetting the password.", ex);
            }
        }
        public async Task<string> GetIdFromToken()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
                throw new Exception("Token not found");

            var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                throw new Exception("Invalid token");

            var userId = jwtToken.Claims.First(claim => claim.Type == "id").Value;

            return userId;
        }
        private string GenerateResetToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var byteArray = new byte[32];
                rng.GetBytes(byteArray);
                return Convert.ToBase64String(byteArray);
            }
        }
    }
}
