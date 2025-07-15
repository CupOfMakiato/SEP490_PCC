namespace Server.Application.DTOs.UserChecklist
{
    public class CustomChecklistDTO
    {
        public string TaskName { get; set; }
        public int Trimester { get; set; } // 1, 2, 3
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
