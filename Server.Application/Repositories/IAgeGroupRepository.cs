using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IAgeGroupRepository : IGenericRepository<AgeGroup>
    {
        Task<AgeGroup> GetGroupByUserDateOfBirthAndTrimester(DateTime dateOfBirth, int trimester);
    }
}
