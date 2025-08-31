using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IEnergySuggestionRepository : IGenericRepository<EnergySuggestion>
    {
        Task<EnergySuggestion> GetEnergySuggestionByAgeAndTrimester(int age, int trimester);
        Task<EnergySuggestion> GetEnergySuggestionByTrimester(int trimester);
        Task<EnergySuggestion> GetEnergySuggestionByAgeGroupIdAndTrimester(Guid ageGroupId, int trimester);
        Task<EnergySuggestion> GetEnergySuggestionByAgeAndTrimester(int age, int trimester, int activityLevel);
        Task<EnergySuggestion> GetEnergySuggestionByAgeGroupIdAndTrimester(Guid ageGroupId, int trimester, int activityLevel);
    }
}
