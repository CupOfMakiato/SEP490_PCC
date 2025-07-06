using Server.Application.Abstractions.RequestAndResponse.Symptom;
using Server.Application.DTOs.Symptom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.SymptomExtensions
{
    public static class SymptomExtensions
    {
        public static AddSymptomDTO ToAddSymptomDTO(this AddSymptomRequest AddSymptomRequest)
        {
            return new AddSymptomDTO
            {
                UserId = AddSymptomRequest.UserId,
                SymptomName = AddSymptomRequest.SymptomName
            };
        }
    }
}
