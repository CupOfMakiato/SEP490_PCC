using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ITemplateChecklistRepository : IGenericRepository<TemplateChecklist>
    {
        Task<List<TemplateChecklist>> GetAllTemplateChecklists();
        Task<List<TemplateChecklist>> GetAllActiveTemplateChecklists();
        Task<List<TemplateChecklist>> GetAllInActiveTemplateChecklists();
        Task<TemplateChecklist> GetTemplateChecklistById(Guid id);
        Task<List<TemplateChecklist>> GetAllCompletedTemplateChecklists();
        Task<List<TemplateChecklist>> GetAllInCompleteTemplateChecklists();
        Task<List<TemplateChecklist>> GetTemplateChecklistsByGrowthDataId(Guid growthDataId);
        Task<List<TemplateChecklist>> GetTemplateChecklistsByTrimester(int trimester, Guid userId);

    }
}
