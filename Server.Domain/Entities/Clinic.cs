using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        public bool? IsInsuranceAccepted { get; set; } = false;
        public Guid UserId { get; set; }
        public User User { get; set; }

        //Clinic can have many reviews
        public ICollection<Review> ReviewedByUsers { get; set; }

        // Clinic can have many consultants
        public ICollection<Consultant> Consultants { get; set; }
    }
}
