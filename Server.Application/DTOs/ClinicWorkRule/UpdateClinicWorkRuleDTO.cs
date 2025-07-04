using Server.Application.DTOs.DailySchedule;

namespace Server.Application.DTOs.ClinicWorkRule
{
    public class UpdateClinicWorkRuleDTO
    {
        public Guid ClinicId { get; set; }
        public string? Annoucement { get; set; }
    }
}
