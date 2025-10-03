using Microsoft.Extensions.Hosting;
using Server.Application.Commons;
using Server.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Services
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly IEmailService _emailService;

        public EmailBackgroundService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var job in EmailQueue.Channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _emailService.SendEmailAsync(job);
                }
                catch (Exception ex)
                {
                    // log error
                }
            }
        }
    }

}
