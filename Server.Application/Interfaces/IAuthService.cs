﻿using Google.Apis.Auth;
using Server.Application.DTOs.Auth;
using Server.Application.DTOs.User;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetIdFromToken();
        //LOGIN
        Task<Authenticator> LoginAsync(LoginDTO loginDTO);
        Task<Authenticator> RefreshToken(string token);
        Task<bool> DeleteRefreshToken(Guid userId);

        //REGISTER
        Task RegisterUserAsync(UserRegistrationDTO userRegistrationDto);
        Task<User> GetByVerificationToken(string token);
        Task<bool> VerifyOtpAsync(string email, string otp);

        // Resend OTP
        Task<bool> ResendOtp(string email);



        //REGISTER Shop
        //Task RegisterShopAsync(ShopRegisterDTO shopRegisterDTO);
        Task<bool> VerifyOtpAndCompleteRegistrationAsync(string email, string otp);
        //Google
        /*        Task<Result<object>> UserCompleteSignUpByGoogle(SignupGoogleRequest userRegistrationDto);*/
        //CHANGE PASSWORD 
        Task ChangePasswordAsync(string email, ChangePasswordDTO changePasswordDto);

        //FORGOT PASSWORD
        Task RequestPasswordResetAsync(ForgotPasswordRequestDTO forgotPasswordRequestDto);
        Task ResetPasswordAsync(ResetPasswordDTO resetPasswordDto);
    }
}
