using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class Disease : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string TreatmentOptions { get; set; }
        public string PregnancyRelated { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public TypeOfDesease TypeOfDesease { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
