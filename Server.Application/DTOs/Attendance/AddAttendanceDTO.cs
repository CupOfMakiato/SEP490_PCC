using Server.Domain.Enums;

namespace Server.Application.DTOs.Attendance
{
    public class AddAttendanceDTO
    {
        public Guid ConsultantId { get; set; }
        public Guid ClinicId { get; set; }
        public DayOfWeek Date { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public string Note { get; set; }
    }
}
