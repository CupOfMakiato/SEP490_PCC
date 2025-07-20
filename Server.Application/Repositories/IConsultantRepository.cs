using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IConsultantRepository : IGenericRepository<Consultant>
    {
        public Task<Consultant> GetConsultantByIdAsync(Guid consultantId);
    }
}
