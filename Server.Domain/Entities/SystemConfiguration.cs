namespace Server.Domain.Entities
{
    public class SystemConfiguration : BaseEntity
    {
        public long? NameMinLength { get; set; }
        public long? NameMaxLength { get; set; }
        public long? DescriptionMinLength { get; set; }
        public long? DescriptionMaxLength { get; set; }
        public long? TrimesterMinValue { get; set; }
        public long? TrimesterMaxValue { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
