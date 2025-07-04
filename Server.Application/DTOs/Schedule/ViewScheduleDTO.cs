using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.User;

namespace Server.Application.DTOs.Schedule
{
    public class ViewScheduleDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public ViewConsultantDTO Consultant { get; set; }
        public UserDTO BookedByUser { get; set; }
    }
}
