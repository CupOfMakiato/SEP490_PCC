using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public bool IsInsuranceAccepted { get; set; }

        public ICollection<Consultant> Consultants { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
