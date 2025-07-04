using Server.Application.DTOs.DailySchedule;

namespace Server.Application.DTOs.ClinicWorkRule
{
    public class ViewClinicWorkRuleDTO
    {
        public Guid ClinicId { get; set; }
        public int TotalWorkingDays { get; set; }
        public string Annoucement { get; set; }
        public List<DayOfWeek>? DaysOff { get; set; }
        public ICollection<ViewDailyScheduleDTO>? DailySchedules { get; set; }
    }
}
