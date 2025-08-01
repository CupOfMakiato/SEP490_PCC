using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IAgeGroupRepository : IGenericRepository<AgeGroup>
    {
        Task<AgeGroup> GetAgeGroupByUserDateOfBirth(DateTime dateOfBirth);
        Task<AgeGroup> GetAgeGroupFrom20To29();
    }
}
