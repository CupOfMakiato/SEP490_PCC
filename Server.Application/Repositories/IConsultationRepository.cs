using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IConsultationRepository : IGenericRepository<Consultation>
    {
        public Task<Consultation> GetConsultationByIdAsync(Guid consultationId);
        public Task<List<Consultation>> GetConsultationByConsultantIdAsync(Guid consultantId);
        public Task<Consultation> GetConsultationByUserIdAsync(Guid userId);
    }
}
