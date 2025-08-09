using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Symptom;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IRecordedSymptomService
    {
        // view
        Task<Result<List<ViewSymptomDTO>>> ViewAllCheckedTemplateSymptoms();
        Task<Result<List<ViewSymptomDTO>>> ViewAllUncheckedTemplateSymptoms();

        Task<Result<List<ViewSymptomDTO>>> ViewAllSymptoms(Guid journalId);
        Task<Result<List<ViewSymptomDTO>>> ViewAllSymptomsForUser(Guid userId);
        Task<Result<ViewSymptomDTO>> ViewSymptomById(Guid id);
        //add
        Task<Result<object>> AddNewTemplateSymptom(AddSymptomDTO addSymptomDTO);
        Task<List<RecordedSymptom>> ReuseExistingOrAddNewCustom(Guid userId, IEnumerable<string> symptomNames);
        // delete
        Task<Result<object>> DeleteRecordedSymptom(Guid id);
        // update
        Task<Result<object>> EditTemplateSymptom(EditSymptomDTO editSymptomDTO);
        Task<Result<object>> MarkTemplateSymptomAsChecked(Guid symptomId);
    }
}
