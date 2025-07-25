using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Guid SlotId { get; set; }
        public Slot Slot { get; set; }
        public Guid? ConsultantId { get; set; }
        public Consultant? Consultant { get; set; }
        public Guid? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
