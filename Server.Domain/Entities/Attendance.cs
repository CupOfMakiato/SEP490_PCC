using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public Guid ConsultantId { get; set; }
        public Guid ClinicId { get; set; }
        public DayOfWeek Date { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; } // e.g., "Present", "Absent", "Late"
        public string Note { get; set; }

        public Consultant Consultant { get; set; }
        public Clinic Clinic { get; set; }
    }
}
