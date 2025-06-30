using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IConsultantRepository : IGenericRepository<Consultant>
    {
        public Task<Consultant> GetConsultantByIdAsync(Guid consultantId);
        public Task<List<Consultant>> GetConsultantByNameAsync(string name);
        public Task<List<Consultant>> GetConsultantsAsync();
    }
}
