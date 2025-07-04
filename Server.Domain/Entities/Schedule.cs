using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Guid ConsultantId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Guid? BookedByUserId { get; set; }

        public Consultant Consultant { get; set; }
        public User BookedByUser { get; set; }
    }
}
