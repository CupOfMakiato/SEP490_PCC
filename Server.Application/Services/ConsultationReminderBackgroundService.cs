using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Application.Interfaces;

namespace Server.Application.Services
{
    public class ConsultationReminderBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ConsultationReminderBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var offlineConsultationService = scope.ServiceProvider.GetRequiredService<IOfflineConsultationService>();
                    await offlineConsultationService.SendOfflineConsultationRemindersAsync();
                }
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Run every 24 hours
            }
        }
    }
}
