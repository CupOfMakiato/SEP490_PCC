using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface INutrientSuggestionService
    {
        public Task<Result<bool>> SoftDeleteNutrientSuggestion(Guid Id);
        public Task<Result<NutrientSuggetion>> CreateNutrientSuggestion(CreateNutrientSuggestionRequest request);
        public Task<Result<NutrientSuggetion>> UpdateNutrientSuggestion(UpdateNutrientSuggestionRequest request);
        public Task<Result<object>> GetEssentialNutritionalNeedsInOneDay(GetEssentialNutritionalNeedsInOneDayRequest request);
    }
}
