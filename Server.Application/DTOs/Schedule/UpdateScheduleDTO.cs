using Server.Application.DTOs.Slot;

namespace Server.Application.DTOs.Schedule
{
    public class UpdateScheduleDTO
    {
        public Guid Id { get; set; }
        public AddSlotDTO Slot { get; set; }
    }
}
