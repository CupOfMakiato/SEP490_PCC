using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Symptom
{
    public class EditSymptomRequest
    {
        public Guid SymptomId { get; set; }
        public string SymptomName { get; set; } = string.Empty;
        public bool? IsActive { get; set; } = true;
    }
}
