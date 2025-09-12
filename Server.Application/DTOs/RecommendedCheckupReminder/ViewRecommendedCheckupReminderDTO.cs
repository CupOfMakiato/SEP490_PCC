using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.RecommendedCheckupReminder
{
    public class ViewRecommendedCheckupReminderDTO
    {
        public Guid Id { get; set; }
        public Guid GrowthDataId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }

        // Optional for recommended checkups
        public int? RecommendedStartWeek { get; set; } // usually 4 weeks span
        public int? RecommendedEndWeek { get; set; }
        public CheckupType Type { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
