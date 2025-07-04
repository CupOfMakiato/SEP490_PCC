using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IClinicWorkRuleRepository : IGenericRepository<ClinicWorkRule>
    {
        public Task<ClinicWorkRule> GetClinicWorkRuleAsync(Guid clinicId);
        public Task<(List<DayOfWeek> DayOffs, int TotalWorkingDays)> CalDaysOffAndTotalWorkingDaysAsync(Guid clinicId);
    }
}
