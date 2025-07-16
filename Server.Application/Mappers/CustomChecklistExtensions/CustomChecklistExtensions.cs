using Server.Application.Abstractions.RequestAndResponse.CustomChecklist;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.Journal;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.CustomChecklistExtensions
{
    public static class CustomChecklistExtensions
    {
        public static CustomChecklist ToCustomChecklist(this CreateCustomChecklistDTO CreateCustomChecklistDTO)
        {
            return new CustomChecklist
            {
                Id = Guid.NewGuid(),
                GrowthDataId = CreateCustomChecklistDTO.GrowthDataId,
                TaskName = CreateCustomChecklistDTO.TaskName,
                Trimester = CreateCustomChecklistDTO.Trimester,
                IsCompleted = false,
                IsActive = true,
                CompletedDate = null,
            };
        }
        public static CreateCustomChecklistDTO ToCreateCustomChecklistDTO(this CreateNewCustomChecklistRequest CreateNewCustomChecklistRequest)
        {
            return new CreateCustomChecklistDTO
            {
                GrowthDataId = CreateNewCustomChecklistRequest.GrowthDataId,
                TaskName = CreateNewCustomChecklistRequest.TaskName,
                Trimester = CreateNewCustomChecklistRequest.Trimester,
            };
        }
    }
}
