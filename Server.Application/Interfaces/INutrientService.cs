using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Nutrient;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface INutrientService
    {
        public Task<Nutrient> GetNutrientByIdAsync(Guid nutrientId);
        public Task<List<Nutrient>> GetNutrientsAsync();
        public Task<bool> SoftDeleteNutrient(Guid nutrientId);
        public Task<bool> DeleteNutrient(Guid nutrientId);
        public Task<Result<Nutrient>> CreateNutrient(CreateNutrientRequest request);
        public Task<bool> UpdateNutrient(Nutrient nutrient);
    }
}
