using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public bool IsInsuranceAccepted { get; set; }
        public bool IsActive { get; set; }
        public string Specializations { get; set; }
        public Guid UserId { get; set; }


        public ICollection<Consultant> Consultants { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public Media? ImageUrl { get; set; }
        public User User { get; set; }
    }
}
