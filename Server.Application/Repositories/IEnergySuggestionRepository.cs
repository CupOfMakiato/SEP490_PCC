using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IEnergySuggestionRepository : IGenericRepository<EnergySuggestion>
    {
        Task<EnergySuggestion> GetEnergySuggestionByAgeGroupAndTrimester(int age, int trimester);
    }
}
