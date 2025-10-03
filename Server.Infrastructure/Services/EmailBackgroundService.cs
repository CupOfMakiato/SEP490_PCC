using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Application.Commons;
using Server.Application.Interfaces;
using Server.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Infrastructure.Services
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailBackgroundService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var job in EmailQueue.Channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    var apiKey = _configuration["Resend:ApiKey"];
                    var fromEmail = _configuration["Resend:FromEmail"];
                    var toEmail = job.To;

                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                    var payload = new
                    {
                        from = fromEmail,
                        to = new[] { toEmail },
                        subject = job.Subject,
                        html = job.Body
                    };

                    var json = JsonSerializer.Serialize(payload);
                    var response = await httpClient.PostAsync("https://api.resend.com/emails", new StringContent(json, Encoding.UTF8, "application/json"));
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("Resend: Email sent to {Recipient}", toEmail);
                    }

                    //await _emailService.SendEmailAsync(job);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }

}
