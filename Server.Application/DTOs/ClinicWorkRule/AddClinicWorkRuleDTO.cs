using Server.Application.DTOs.DailySchedule;

namespace Server.Application.DTOs.ClinicWorkRule
{
    public class AddClinicWorkRuleDTO
    {
        public Guid ClinicId { get; set; }
        public string Annoucement { get; set; }
        public ICollection<GetDailyScheduleDTO>? DailySchedules { get; set; }
    }
}
