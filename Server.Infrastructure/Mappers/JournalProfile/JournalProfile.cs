using AutoMapper;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.JournalProfile
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<Journal, ViewJournalDTO>()
            .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.JournalCreatedBy != null ? new GetUserDTO { Id = src.JournalCreatedBy.Id, UserName = src.JournalCreatedBy.UserName } : null))
            .ForMember(dest => dest.Symptoms, opt => opt.MapFrom(src =>
                src.JournalSymptoms
                .Where(js => js.RecordedSymptom != null && js.RecordedSymptom.IsActive && !js.RecordedSymptom.IsDeleted)
                .Select(js => new SymptomDTO
                {
                SymptomName = js.RecordedSymptom.SymptomName,
                IsTemplate = js.RecordedSymptom.IsTemplate
                }).ToList()))

            .ForMember(dest => dest.Mood, opt => opt.MapFrom(src =>
                src.MoodNotes))

            .ReverseMap()
            ;
            CreateMap<Journal, JournalDTO>().ReverseMap();
        }
    }
}
