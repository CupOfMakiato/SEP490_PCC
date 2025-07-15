namespace Server.Application.DTOs.UserChecklist
{
    public class ViewCustomChecklistDTO
    {
        public Guid Id { get; set; }
        public Guid GrowthDataId { get; set; }
        public string TaskName { get; set; }
        public int Trimester { get; set; } // 1, 2, 3
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public bool IsActive { get; set; } = true;
        
    }
}
