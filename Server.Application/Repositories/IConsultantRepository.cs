using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IConsultantRepository : IGenericRepository<Consultant>
    {
        public Task<Consultant> GetConsultantByIdAsync(Guid consultantId);
        public Task<Consultant> GetConsultantByConsultantIdAsync(Guid consultantId);
        //public Task<bool> HasOverlappingScheduleAsync(Guid consultantId,
        //                                              DateTime startTime,
        //                                              DateTime endTime,
        //                                              int dayOfWeek);
        public Task<Consultant> GetConsultantByUserIdAsync(Guid userId);
    }
}
