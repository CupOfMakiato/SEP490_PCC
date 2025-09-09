using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Server.Application.Interfaces;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using RestSharp;
using Server.Application.DTOs.User;
using Org.BouncyCastle.Asn1.Crmf;
using System.Text.Json;
using RestSharp.Authenticators;
using System.Net.Http.Headers;
using System.Text;

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

        //public async Task<bool> SendEmailAsync(EmailDTO request)
        //{
        //    try
        //    {
        //        var apiKey = _configuration["Mailjet:ApiKey"];
        //        var apiSecret = _configuration["Mailjet:ApiSecret"];
        //        var fromEmail = _configuration["Mailjet:FromEmail"];
        //        var fromName = _configuration["Mailjet:FromName"];

        //        var options = new RestClientOptions("https://api.mailjet.com/v3.1/send")
        //        {
        //            Authenticator = new HttpBasicAuthenticator(apiKey, apiSecret)
        //        };

        //        var client = new RestClient(options);

        //        var requestBody = new
        //        {
        //            Messages = new[]
        //            {
        //        new
        //        {
        //            From = new { Email = fromEmail, Name = fromName },
        //            To = new[] { new { Email = request.To, Name = request.To } },
        //            Subject = request.Subject,
        //            HTMLPart = request.Body
        //        }
        //    }
        //        };

        //        var jsonBody = JsonSerializer.Serialize(requestBody);

        //        var restRequest = new RestRequest()
        //            .AddHeader("Content-Type", "application/json")
        //            .AddStringBody(jsonBody, DataFormat.Json);

        //        var response = await client.ExecutePostAsync(restRequest);

        //        if (response.IsSuccessful)
        //        {
        //            _logger.LogInformation("✅ Email sent successfully to {Recipient}", request.To);
        //            return true;
        //        }

        //        _logger.LogError("""
        //Failed to send email to {Recipient}
        //→ StatusCode: {StatusCode}
        //→ Response Content: {Content}
        //→ ErrorMessage: {ErrorMessage}
        //→ Sent JSON: {JsonBody}
        //""", request.To, response.StatusCode, response.Content, response.ErrorMessage, jsonBody);

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("""
        //Exception while sending email:
        //→ Message: {ExceptionMessage}
        //→ StackTrace: {StackTrace}
        //""", ex.Message, ex.StackTrace);

        //        return false;
        //    }
        //}
        public async Task<bool> SendEmailAsync(EmailDTO request)
        {
            try
            {
                var apiKey = _configuration["Resend:ApiKey"];
                var fromEmail = _configuration["Resend:FromEmail"];
                var toEmail = request.To;

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var payload = new
                {
                    from = fromEmail,
                    to = new[] { toEmail },
                    subject = request.Subject,
                    html = request.Body
                };

                var json = JsonSerializer.Serialize(payload);
                var response = await httpClient.PostAsync("https://api.resend.com/emails", new StringContent(json, Encoding.UTF8, "application/json"));
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Resend: Email sent to {Recipient}", toEmail);
                    return true;
                }

                _logger.LogError("Resend failed: {Status} - {Content}", response.StatusCode, content);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while sending email via Resend");
                return false;
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

        public async Task ReSendOtpEmail(string email, string otp)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "New Email Re-Verification OTP",
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
                            <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
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
                    <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
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
                    <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
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
                            <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
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
                            <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
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
                            <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
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
                            <p style='color: #555;'>Best regards,<br />Nestly Care Companion</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }
        // Reminder Email
        public async Task SendNewlyCreatedCheckupReminder(string email)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Action Needed: Schedule Your Checkup",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6; background-color: #f9f9f9; padding: 20px;'>
                         <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border: 1px solid #e0e0e0; border-radius: 10px; box-shadow: 0px 4px 6px rgba(0,0,0,0.1);'>
                            <p>Hello,</p>
                            <p>We noticed that a new checkup reminder has been created for you. Please make sure to schedule your appointment as soon as possible.</p>
                            <p>Taking action early helps us ensure the best possible care during your pregnancy journey.</p>
                            <p style='margin-top: 30px;'>If you’ve already scheduled your checkup, you can ignore this message.</p>
                            <p style='color: #555;'>Thank you for choosing our care system! <br />Nestly Care Companion</p>
                            <hr style='margin-top: 40px;' />
                            <p style='font-size: 12px; color: #999;'>This is an automated message. Please do not reply directly to this email.</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendUnScheduledCheckupReminder(string email)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Action Needed: Schedule Your Checkup",
                Body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                        <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                            <h2 style='color: #e67e22;'>Schedule Your Checkup</h2>
                            <p style='color: #555;'>We noticed that you have not yet scheduled your upcoming checkup.</p>
                            <p style='color: #555;'>To stay on track with your care plan, please schedule your checkup as soon as possible.</p>
                            <p style='color: #555;'>If you need assistance or have questions, our support team is here to help.</p>
                            <p style='color: #555;'>Wishing you good health,<br />Nestly Care Companion</p>
                            <hr style='margin-top: 40px;' />
                            <p style='font-size: 12px; color: #999;'>This is an automated message. Please do not reply directly to this email.</p>
                        </div>
                    </body>
                    </html>"
            };

            await SendEmailAsync(emailDto);
        }
        public async Task SendUpcomingCheckupReminder(string email, string reason)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Upcoming Checkup Schedule Reminder",
                Body = $@"
                    <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                    <h2 style='color: #2c3e50;'>Upcoming Checkup Reminder</h2>
                    <p style='color: #555;'>This is a friendly reminder that you have an upcoming checkup scheduled for tomorrow.</p>
                    <p style='color: #555;'>Details: {reason}</p>
                    <p style='color: #555;'>Please ensure you are prepared and arrive on time. If you have any questions, feel free to contact us.</p>
                    <p style='color: #555;'>Wishing you good health,<br />Nestly Care Companion</p>
                    <hr style='margin-top: 40px;' />
                    <p style='font-size: 12px; color: #999;'>This is an automated message. Please do not reply directly to this email.</p>
                </div>
            </body>
            </html>"
            };

            await SendEmailAsync(emailDto);
        }
        public async Task SendMissedScheduledCheckupReminder(string email, string reason)
        {
            var emailDto = new EmailDTO
            {
                To = email,
                Subject = "Missed Checkup!",
                Body = $@"
            <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                    <h2 style='color: #c0392b;'>You Missed a Scheduled Checkup</h2>
                    <p style='color: #555;'>We noticed that you missed your scheduled checkup.</p>
                    <p style='color: #555;'>Checkup Info: {reason}</p>
                    <p style='color: #555;'>It's important to stay on track with your care plan. Please log in to reschedule your appointment as soon as possible.</p>
                    <p style='color: #555;'>If you have any questions or concerns, feel free to reach out to our support team for assistance.</p>
                    <p style='color: #555;'>Wishing you good health,<br />Nestly Care Companion</p>
                    <hr style='margin-top: 40px;' />
                    <p style='font-size: 12px; color: #999;'>This is an automated message. Please do not reply directly to this email.</p>
                </div>
            </body>
            </html>"
            };

            await SendEmailAsync(emailDto);
        }

        public async Task SendEmergencyBiometricAlert(string email, string subject, string body)
        {
            // Convert plain text list into HTML <ul>
            var formattedBody = body
                .Replace("We detected the following abnormal readings:", "")
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(line => $"<li>{line.Trim()}</li>");

            var emailDto = new EmailDTO
            {
                To = email,
                Subject = subject,
                Body = $@"
        <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6; background-color: #f9fafb; padding: 20px; margin:0;'>
                <div style='max-width: 600px; margin: auto; background: #fff; border: 1px solid #ddd; border-radius: 10px; padding: 20px;'>
                    
                    <h2 style='color: #c0392b; margin-top: 0;'>Emergency Alert</h2>

                    <p style='color: #333; margin: 0 0 10px 0;'>We detected the following abnormal readings in your latest journal entry:</p>
                    
                    <!-- Fix Gmail quote formatting by resetting styles -->
                    <div style='all:unset; display:block; background:#fff4f4; border-left: 5px solid #d93025; padding: 15px; border-radius: 6px; margin:0;'>
                        <p style='margin: 0; padding-left: 20px; color: #555;'>
                            {string.Join("\n", formattedBody)}
                        </p>
                    </div>

                    <p style='margin-top: 20px; color: #333;'>
                        Please <strong>book a consultation immediately</strong> for your safety.
                    </p>

                    <p style='margin-top: 30px; color: #333;'>
                        Stay safe,<br />
                        <strong>Nestly Care Companion</strong>
                    </p>

                    <hr style='margin: 30px 0; border: none; border-top: 1px solid #eee;' />
                    <p style='font-size: 12px; color: #999; text-align: center; margin:0;'>
                        This is an automated message. Please do not reply directly to this email.
                    </p>
                </div>
            </body>
        </html>"
            };

            await SendEmailAsync(emailDto);
        }



    }
}
