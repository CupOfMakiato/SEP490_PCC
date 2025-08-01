using AutoMapper;
using Server.Application.DTOs.Feedback;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.FeedbackProfile
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<ViewFeedbackDTO, Feedback>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id)); ;

            CreateMap<AddFeedbackDTO, Feedback>().ReverseMap();

            CreateMap<UpdateFeedbackDTO, Feedback>().ReverseMap();
        }
    }
}
