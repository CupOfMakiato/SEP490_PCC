﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Server.Application.Interfaces;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Server.Application.DTOs.User;

namespace Server.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailUserName"]));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Body
            };

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_configuration["EmailHost"], 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration["EmailUserName"], _configuration["EmailPassword"]);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your needs
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }

        public async Task SendVerificationEmailAsync(string email, string token)
        {
            var verificationUrl = $"https://localhost:7238/api/auth/verify?token={token}";
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Email Verification",
                Body =
                    $"Please verify your email by clicking on the following link: <a href='{verificationUrl}'>Verify Email</a>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendOtpEmailAsync(string email, string otp)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Email Verification OTP",
                Body = $"Your OTP for email verification is: {otp}"
            };

            await SendEmailAsync(emailDto);
        }

        //PENDING MAIL
        public async Task SendPendingEmailAsync(string email)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Account Pending Approval",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                        <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                            <h2 style='color: #333;'>Thank you for registering as an staff!</h2>
                            <p style='color: #555;'>We have received your registration and it is currently being reviewed by our admin team.</p>
                            <p style='color: #555;'>You will receive a notification once your account is approved. Please be patient during this process.</p>
                            <p style='color: #555;'>Thank you for your understanding.</p>
                            <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }
        public async Task SendActiveEmailAsync(string email)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Account Reactivation",
                Body = $@"
            <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                    <h2 style='color: #333;'>Welcome Back!</h2>
                    <p style='color: #555;'>We are excited to inform you that your account has been reactivated. You can now log in and continue using our system.</p>
                    <p style='color: #555;'>Thank you for being a valued member of our community.</p>
                    <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                </div>
            </body>
            </html>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendDeactiveEmailAsync(string email, string reason)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Account Deactivation Notice",
                Body = $@"
            <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                    <h2 style='color: #333;'>Account Deactivation</h2>
                    <p style='color: #555;'>We regret to inform you that your account has been deactivated.</p>
                    <p style='color: #555;'>Reason: {reason}</p>
                    <p style='color: #555;'>If you have any questions or need further assistance, please contact our support team.</p>
                    <p style='color: #555;'>We appreciate your understanding.</p>
                    <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                </div>
            </body>
            </html>"
            };

            await SendEmailAsync(emailDto);
        }
        public async Task SendRejectionEmailAsync(string email, string reason)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Instructor Rejection",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                        <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                            <h2 style='color: #333;'>Registration Update</h2>
                            <p style='color: #555;'>We regret to inform you that your account registration has been rejected.</p>
                            <p style='color: #555;'>Reason: {reason}</p>
                            <p style='color: #555;'>If you have any questions or need further assistance, please contact our support team.</p>
                            <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendApprovalEmailAsync(string email)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Account Approval",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                        <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                            <h2 style='color: #333;'>Congratulations!</h2>
                            <p style='color: #555;'>Your account has been approved. You can now log in and start using the system.</p>
                            <p style='color: #555;'>Thank you for joining our system.</p>
                            <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendApprovalServiceAsync(string email)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Service Approval",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                        <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                            <h2 style='color: #333;'>Congratulations!</h2>
                            <p style='color: #555;'>Your service has been approved.</p>
                            <p style='color: #555;'>Thank you for use my website.</p>
                            <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendRejectServiceAsync(string email, string reason)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Service Rejection",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                        <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                            <h2 style='color: #333;'>Service Rejection</h2>
                            <p style='color: #555;'>We regret to inform you that your service registration has been rejected.</p>
                            <p style='color: #555;'>Reason: {reason}</p>
                            <p style='color: #555;'>If you have any questions or need further assistance, please contact our support team.</p>
                            <p style='color: #555;'>Best regards,<br />Pet Setvice Platform</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }
    }
}
