using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.TemplateChecklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ITemplateChecklistService
    {
        //view
        Task<Result<List<ViewTemplateChecklistDTO>>> ViewAllTemplateChecklists(Guid growthDataId);
    }
}
