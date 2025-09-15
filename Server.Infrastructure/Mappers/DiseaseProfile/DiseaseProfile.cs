using AutoMapper;
using Server.Application.DTOs.Disease;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.DiseaseProfile
{
    public class DiseaseProfile : Profile
    {
        public DiseaseProfile()
        {
            CreateMap<Disease, CreateDiseaseRequest>().ReverseMap();
            CreateMap<Disease, GetDiseaseResponse>().ReverseMap();
        }
    }
}
