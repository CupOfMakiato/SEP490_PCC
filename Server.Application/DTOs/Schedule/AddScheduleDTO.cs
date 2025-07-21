using Server.Application.DTOs.Slot;

namespace Server.Application.DTOs.Schedule
{
    public class AddScheduleDTO
    {
        public Guid ConsultantId { get; set; }
        public AddSlotDTO Slot { get; set; }
    }
}
