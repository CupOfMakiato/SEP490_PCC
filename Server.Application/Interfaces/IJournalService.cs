using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IJournalService
    {
        // view
        Task<Result<List<ViewJournalDTO>>> ViewAllJournals();
        Task<Result<ViewJournalDTO>> ViewJournalById(Guid journalId);
        Task<Result<ViewJournalDetailDTO>> ViewJournalDetail(Guid journalId);
        Task<Result<List<ViewJournalDTO>>> ViewJournalsByGrowthDataId(Guid growthDataId);
        // create
        Task<Result<object>> CreateNewJournalEntryForCurrentWeek(CreateNewJournalEntryForCurrentWeekDTO CreateNewJournalEntryForCurrentWeekDTO);
        // edit
        Task<Result<object>> EditJournalEntry(EditJournalEntryDTO EditJournalEntryDTO);
        // delete 
        Task<Result<object>> DeleteJournal(Guid journalId);
    }
}
