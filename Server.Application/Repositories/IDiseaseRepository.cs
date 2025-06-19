using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IDiseaseRepository : IGenericRepository<Disease>
    {
        public Task<IEnumerable<Disease>> GetDiseases();
        public Task<Disease> GetDiseaseById(Guid diseaseId);
        public void DeleteDisease(Disease disease);
    }
}
