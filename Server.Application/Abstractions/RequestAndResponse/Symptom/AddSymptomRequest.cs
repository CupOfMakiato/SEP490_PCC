using Server.Application.DTOs.Symptom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Symptom
{
    public class AddSymptomRequest
    {
        public Guid UserId { get; set; }
        public string SymptomName { get; set; }

    }
}
