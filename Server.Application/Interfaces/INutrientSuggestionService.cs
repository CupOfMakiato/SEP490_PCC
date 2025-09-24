using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface INutrientSuggestionService
    {
        public Task<Result<bool>> SoftDeleteNutrientSuggestion(Guid Id);
        public Task<Result<bool>> DeleteNutrientSuggestion(Guid Id);
        public Task<Result<bool>> DeleteAttribute(Guid nutrientSuggestionId, Guid attributeId);
        public Task<Result<NutrientSuggestion>> CreateNutrientSuggestion(CreateNutrientSuggestionRequest request);
        public Task<Result<NutrientSuggestion>> UpdateNutrientSuggestion(UpdateNutrientSuggestionRequest request);
        public Task<Result<object>> GetEssentialNutritionalNeedsInOneDay(GetEssentialNutritionalNeedsInOneDayRequest request);
        public Task<Result<NSAttribute>> AddNutrientSuggestionAttribute(AddNutrientSuggestionAttributeRequest request);
        public Task<Result<NSAttribute>> UpdateNutrientSuggestionAttribute(UpdateNutrientSuggestionAttributeRequest request);
        public Task<Result<List<NutrientSuggestionDTO>>> ViewNutrientSuggestions();
        public Task<Result<NutrientSuggestionDTO>> ViewNutrientSuggestionById(Guid id);
    }
}
