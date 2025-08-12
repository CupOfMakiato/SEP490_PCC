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
                SymptomName = js.RecordedSymptom.SymptomName
                }).ToList()))

            .ForMember(dest => dest.Mood, opt => opt.MapFrom(src =>
                src.MoodNotes))

            .ForMember(dest => dest.CurrentWeight, opt => opt.MapFrom(src =>
                src.CurrentWeight))

            .ReverseMap()
            ;
            CreateMap<Journal, JournalDTO>()
                
                .ReverseMap();
            CreateMap<Journal, ViewJournalDetailDTO>()
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.JournalCreatedBy != null ? new GetUserDTO { Id = src.JournalCreatedBy.Id, UserName = src.JournalCreatedBy.UserName } : null))
            .ForMember(dest => dest.Symptoms, opt => opt.MapFrom(src =>
                src.JournalSymptoms
                .Where(js => js.RecordedSymptom != null && js.RecordedSymptom.IsActive && !js.RecordedSymptom.IsDeleted)
                .Select(js => new SymptomDTO
                {
                    SymptomName = js.RecordedSymptom.SymptomName
                }).ToList()))

            .ForMember(dest => dest.Mood, opt => opt.MapFrom(src =>
                src.MoodNotes))
            .ForMember(dest => dest.RelatedImages, opt => opt.MapFrom(src =>
                src.Media != null
            ? src.Media
                .Where(m => m.FilePublicId != null && m.FilePublicId.Contains("journal-related"))
                .Select(m => m.FileUrl)
                .ToList()
            : new List<string>()))

            .ForMember(dest => dest.UltraSoundImages, opt => opt.MapFrom(src =>
                src.Media != null
            ? src.Media
                .Where(m => m.FilePublicId != null && m.FilePublicId.Contains("journal-ultrasound"))
                .Select(m => m.FileUrl)
                .ToList()
            : new List<string>()))

            .ForMember(dest => dest.CurrentWeight, opt => opt.MapFrom(src =>
                src.CurrentWeight))

            .ForMember(dest => dest.SystolicBP, opt => opt.MapFrom(src =>
                src.SystolicBP))

            .ForMember(dest => dest.DiastolicBP, opt => opt.MapFrom(src =>
                src.DiastolicBP))

            .ForMember(dest => dest.HeartRateBPM, opt => opt.MapFrom(src =>
                src.HeartRateBPM))

            .ForMember(dest => dest.BloodSugarLevelMgDl, opt => opt.MapFrom(src =>
                src.BloodSugarLevelMgDl))


            .ReverseMap()
            ;
        }
        
    }
}
