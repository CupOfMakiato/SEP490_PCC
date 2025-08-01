namespace Server.Application.DTOs.Slot
{
    public class AddSlotDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DayOfWeek { get; set; }
    }
}
