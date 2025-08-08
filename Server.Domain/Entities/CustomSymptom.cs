using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class CustomSymptom : BaseEntity
    {
        public string SymptomName { get; set; }
        //public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsChecked { get; set; } = false;
        public DateTime? CheckedDate { get; set; } = null;
        public Guid JournalId { get; set; }
        public Journal Journal { get; set; }

    }
}
