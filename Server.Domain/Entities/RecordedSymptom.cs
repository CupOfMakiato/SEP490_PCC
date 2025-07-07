using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class RecordedSymptom : BaseEntity
    {
        public string SymptomName { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<JournalSymptom> JournalSymptoms { get; set; } = new List<JournalSymptom>();

    }
}
