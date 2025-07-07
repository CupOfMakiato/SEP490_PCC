using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ISymptomRepository : IGenericRepository<RecordedSymptom>
    {
        Task<List<RecordedSymptom>> GetAllSymptoms();
        Task<RecordedSymptom> GetSymptomById(Guid id);
        Task<RecordedSymptom?> GetSymptomByName(string name);
        Task<List<RecordedSymptom>> GetAllSymptomsForUser(Guid userId);
        Task<List<RecordedSymptom>> GetTemplateSymptoms();
        Task<List<RecordedSymptom>> GetCustomSymptomsByUser(Guid userId);
        Task<bool> IsSymptomNameDuplicateForUser(string name, Guid userId);
        Task<bool> IsTemplateSymptomExistsByName(string name);
        Task<RecordedSymptom?> FindReusableSymptom(string name, Guid userId);
    }
}
