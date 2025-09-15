namespace Server.Application.DTOs.Food
{
    public class CreateRecommendFoodForDiseaseRequest
    {
        public Guid DiseaseId { get; set; }
        public List<FoodDiseaseWarningDto> recommendFoodDtos { get; set; }
    }
}
