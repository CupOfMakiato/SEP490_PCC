using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Symptom
{
    public class ViewSymptomDTO
    {
        public Guid Id { get; set; }
        public Guid JournalId { get; set; }
        public string SymptomName { get; set; }
        public bool IsChecked { get; set; } = false;
        public DateTime? CheckedDate { get; set; } = null;
        public bool IsActive { get; set; } = true;
    }
}
