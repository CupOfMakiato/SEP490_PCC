using Server.Application.DTOs.AgeGroup;
using Server.Application.DTOs.Blog;
using Server.Domain.Entities;

namespace Server.Application.Mappers.AgeGroupExtensions
{
    public static class AgeGroupExtensions
    {
        public static AgeGroupDTO ToAgeGroupDTO(this AgeGroup ageGroup)
        {
            return new AgeGroupDTO
            {
                Id = ageGroup.Id,
                FromAge = ageGroup.FromAge,
                ToAge = ageGroup.ToAge,
            };
        }
    }
}
