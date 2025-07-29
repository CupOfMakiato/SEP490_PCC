using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.HangfireInterface
{
    public interface ITailoredReminderEmailService
    {
        Task SendTailoredReminderCheckupEmail();
    }
}
