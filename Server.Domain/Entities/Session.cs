using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Session : BaseEntity
    {
        public Guid ConsultationId { get; set; }
        public Guid SlotId { get; set; }
        public DateTime SessionDate { get; set; }
        public int Trimester { get; set; }
        public int Week { get; set; }
        public string Status { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public bool FollowUpRequired { get; set; }

        public Consultation Consultation { get; set; }
        public Slot Slot { get; set; }
    }
}
