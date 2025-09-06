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
                SymptomName = AddSymptomRequest.SymptomName
            };
        }
        public static EditSymptomDTO ToEditSymptomDTO(this EditSymptomRequest EditSymptomRequest)
        {
            return new EditSymptomDTO
            {
                SymptomId = EditSymptomRequest.SymptomId,
                SymptomName = EditSymptomRequest.SymptomName,
            };
        }
    }
}
