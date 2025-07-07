using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Symptom
{
    public class AddSymptomDTO
    {
        public Guid UserId { get; set; }
        public string SymptomName { get; set; }
    }
}
