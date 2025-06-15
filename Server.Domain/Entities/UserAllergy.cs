using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class UserAllergy
    {
        public Guid UserId { get; set; }
        public Guid AllergyId { get; set; }
        public string Severity { get; set; }
        public string Notes { get; set; }
        public DateTime DiagnosedAt { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
        public Allergy Allergy { get; set; }
    }
}
