using Server.Domain.Enums;

namespace Server.Application.DTOs.Attendance
{
    public class ViewAttendanceDTO
    {
        public Guid Id { get; set; }
        public Guid ConsultantId { get; set; }
        public Guid ClinicId { get; set; }
        public DayOfWeek Date { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Note { get; set; }
    }
}
