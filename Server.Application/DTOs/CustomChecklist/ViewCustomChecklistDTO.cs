namespace Server.Application.DTOs.UserChecklist
{
    public class ViewCustomChecklistDTO
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public int Trimester { get; set; } // 1, 2, 3
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        //public Guid GrowthDataId { get; set; }
    }
}
