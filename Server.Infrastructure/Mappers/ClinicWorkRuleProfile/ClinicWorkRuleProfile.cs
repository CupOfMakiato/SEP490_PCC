using AutoMapper;
using Server.Application.DTOs.ClinicWorkRule;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ClinicWorkRuleProfile
{
    public class ClinicWorkRuleProfile : Profile
    {
        public ClinicWorkRuleProfile()
        {
            CreateMap<ViewClinicWorkRuleDTO, ClinicWorkRule>().ReverseMap();

            CreateMap<AddClinicWorkRuleDTO, ClinicWorkRule>().ReverseMap();

            CreateMap<UpdateClinicWorkRuleDTO, ClinicWorkRule>().ReverseMap();
        }
    }
}
