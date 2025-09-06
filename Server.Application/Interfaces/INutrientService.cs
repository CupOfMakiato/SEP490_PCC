using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Nutrient;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface INutrientService
    {
        public Task<NutrientDTO> GetNutrientByIdAsync(Guid nutrientId);
        public Task<List<NutrientDTO>> GetNutrientsAsync();
        public Task<bool> SoftDeleteNutrient(Guid nutrientId);
        public Task<bool> DeleteNutrient(Guid nutrientId);
        public Task<Result<NutrientDTO>> CreateNutrient(CreateNutrientRequest request);
        public Task<Result<NutrientDTO>> UpdateNutrient(UpdateNutrientRequest request);
        public Task<Result<NutrientDTO>> UpdateNutrientImage(UpdateNutrientImageRequest request);
    }
}
