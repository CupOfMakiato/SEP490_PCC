using Server.Application.DTOs.Slot;

namespace Server.Application.DTOs.Schedule
{
    public class ViewScheduleDTO
    {
        public Guid Id { get; set; }
        public ViewSlotDTO Slot { get; set; }
    }
}
