using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface INutrientSuggetionRepository : IGenericRepository<NutrientSuggestion>
    {
        public Task<List<NutrientSuggestion>> GetNutrientSuggetionListWithAttribute(Guid ageGroupId, int trimester);
        public Task CreateNutrientSuggetionAttribute(NutrientSuggestionAttribute attribute);
        Task<NutrientSuggestion> GetNutrientSuggetionById(Guid id);
        Task<List<NutrientSuggestion>> GetNutrientSuggetions();
        void DeleteNutrientSuggetion(NutrientSuggestion nutrientSuggetion);
    }
}
