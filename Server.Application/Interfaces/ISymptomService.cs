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
    public interface ISymptomService
    {
        Task<Result<List<ViewSymptomDTO>>> ViewAllSymptoms();
        Task<Result<List<ViewSymptomDTO>>> ViewAllSymptomsForUser(Guid userId);
        Task<Result<ViewSymptomDTO>> ViewSymptomById(Guid id);
        Task<Result<object>> AddNewCustomSymptom(AddSymptomDTO addSymptomDTO);
        Task<List<RecordedSymptom>> ReuseExistingOrAddNewCustom(Guid userId, IEnumerable<string> symptomNames);
    }
}
