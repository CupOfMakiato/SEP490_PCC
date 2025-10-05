using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.User
{
    public class UserAllergiesDTO
    {
        public Guid AllergyId { get; set; }
        public string Severity { get; set; }
        public string Notes { get; set; }
        public DateTime DiagnosedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
