using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.EnergySuggestion;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IEnergySuggestionService
    {
        public Task<EnergySuggestion> GetEnergySuggestionByIdAsync(Guid energySuggestionId);
        public Task<List<EnergySuggestion>> GetEnergySuggestionsAsync();
        public Task<bool> SoftDeleteEnergySuggestion(Guid energySuggestionId);
        public Task<bool> DeleteEnergySuggestion(Guid energySuggestionId);
        public Task<Result<EnergySuggestion>> CreateEnergySuggestion(CreateEnergySuggestionRequest request);
        public Task<bool> UpdateEnergySuggestion(UpdateEnergySuggestionRequest request);
    }
}
