using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Reminder : BaseEntity
    {
        public Guid GrowthDataId { get; set; }
        public Guid ClinicId { get; set; }
        public string Note { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string AppointmentType { get; set; }

        public GrowthData GrowthData { get; set; }
        public Clinic Clinic { get; set; }
    }
}
