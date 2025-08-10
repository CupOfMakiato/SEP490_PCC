namespace Server.Application.DTOs.AgeGroup
{
    public class UpdateAgeGroupRequest
    {
        public Guid AgeGroupId { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
    }
}
