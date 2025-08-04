using Server.Application.DTOs.Slot;

namespace Server.Application.DTOs.Schedule
{
    public class AddScheduleDTO
    {
        public Guid DoctorId { get; set; }
        public AddSlotDTO Slot { get; set; }
    }
}
