using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
        public Task<Food> GetFoodByIdAsync(Guid foodId);
        public Task<List<Food>> GetFoodsAsync();
        public void DeleteFood(Food food);
        public Task<bool> DeleteFoodNutrient(Guid foodId, Guid NutrientId);
        public Task<Food> GetFoodWithFoodNutrient(Guid foodId, Guid NutrientId);
        public Task<Food> GetFoodByName(string name);
        public Task<List<Guid>> GetFoodWarningIdsByAllergiesAndDiseases(List<Guid> allergyIds, List<Guid> diseaseIds);
        public Task<List<Food>> GetFoodWarningsByAllergiesAndDiseases(List<Guid> allergyIds, List<Guid> diseaseIds);
    }
}
