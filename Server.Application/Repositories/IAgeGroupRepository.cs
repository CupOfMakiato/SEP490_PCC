using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IAgeGroupRepository : IGenericRepository<AgeGroup>
    {
        Task<AgeGroup> GetAgeGroupByUserDateOfBirth(DateTime dateOfBirth);
        Task<AgeGroup> GetAgeGroupFrom20To29();
        void Delete(AgeGroup ageGroup);
        Task<AgeGroup> GetAgeGroupById(Guid id);
    }
}
