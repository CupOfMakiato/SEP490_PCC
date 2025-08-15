using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.UserChecklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ICustomChecklistService
    {
        // view
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllCustomChecklists();
        Task<Result<ViewCustomChecklistDTO>> ViewCustomChecklistById(Guid id);
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllInCompleteChecklist();
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllCompleteChecklist();
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllActiveCustomChecklists();
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllArchiveCustomChecklists();
        Task<Result<List<ViewCustomChecklistDTO>>> ViewCustomChecklistsByTrimester(int trimester);
        Task<Result<List<ViewCustomChecklistDTO>>> ViewCustomChecklistsByGrowthData(Guid growthDataId);
        // create
        Task<Result<object>> CreateNewCustomChecklist(CreateCustomChecklistDTO CreateCustomChecklistDTO);
        //edit
        Task<Result<object>> EditCustomChecklistInfo(EditCustomChecklistInfoDTO EditCustomChecklistInfoDTO);
        Task<Result<object>> MarkChecklistAsComplete(Guid ChecklistId);
        Task<Result<object>> MarkChecklistAsInComplete(Guid ChecklistId);
        Task<Result<object>> ArchiveCustomChecklist(Guid ChecklistId);
        Task<Result<object>> UnArchiveCustomChecklist(Guid ChecklistId);
        //delete
        Task<Result<object>> DeleteCustomChecklist(Guid ChecklistId);

    }
}
