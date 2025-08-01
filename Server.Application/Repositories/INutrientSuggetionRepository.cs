using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface INutrientSuggetionRepository : IGenericRepository<NutrientSuggetion>
    {
        public Task<List<NutrientSuggetion>> GetNutrientSuggetionListWithAttribute(Guid ageGroupId, int trimester);
    }
}
