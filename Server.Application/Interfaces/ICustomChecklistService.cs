using Server.Application.Abstractions.Shared;
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
        //view
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllCustomChecklists();
        Task<Result<ViewCustomChecklistDTO>> ViewCustomChecklistById(Guid id);
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllInCompleteChecklist();
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllCompleteChecklist();
        Task<Result<List<ViewCustomChecklistDTO>>> ViewAllActiveCustomChecklists();

    }
}
