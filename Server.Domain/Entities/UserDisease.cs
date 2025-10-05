using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class UserDisease
    {
        public Guid UserId { get; set; }
        public Guid DiseaseId { get; set; }

        // When disease was diagnosed
        public DateTime? DiagnosedAt { get; set; }

        // Was this before pregnancy or during pregnancy
        public bool IsBeforePregnancy { get; set; }

        // Guess time to be cured (e.g. doctor’s estimate)
        public DateTime? ExpectedCuredAt { get; set; }

        // Actual cure date
        public DateTime? ActualCuredAt { get; set; }

        // Type of disease: chronic or temporary
        public DiseaseType DiseaseType { get; set; }

        // Is the user cured before expected time
        public bool? IsCured { get; set; }
        public DateTime CreateAt { get; set; }

        public User User { get; set; }
        public Disease Disease { get; set; }
    }
}
