using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.Abstractions.RequestAndResponse.Journal;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.JournalExtensions
{
    public static class JournalExtensions
    {
        public static Journal ToJournal(this CreateNewJournalEntryForCurrentWeekDTO CreateNewJournalEntryForCurrentWeekDTO)
        {
            int trimester = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeek switch
            {
                <= 13 => 1,
                <= 27 => 2,
                _ => 3
            };
            return new Journal
            {
                Id = CreateNewJournalEntryForCurrentWeekDTO.Id,
                GrowthDataId = CreateNewJournalEntryForCurrentWeekDTO.GrowthDataId,
                CurrentWeek = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeek,
                CurrentTrimester = trimester,
                Note = CreateNewJournalEntryForCurrentWeekDTO.Note,
                CurrentWeight = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeight,
                SystolicBP = CreateNewJournalEntryForCurrentWeekDTO.SystolicBP,
                DiastolicBP = CreateNewJournalEntryForCurrentWeekDTO.DiastolicBP,
                HeartRateBPM = CreateNewJournalEntryForCurrentWeekDTO.HeartRateBPM,
                BloodSugarLevelMgDl = CreateNewJournalEntryForCurrentWeekDTO.BloodSugarLevelMgDl,
                JournalSymptoms = new List<JournalSymptom>(),
                MoodNotes = CreateNewJournalEntryForCurrentWeekDTO.MoodNotes ?? Mood.Neutral,
                Media = new List<Media>(),
                CreatedBy = CreateNewJournalEntryForCurrentWeekDTO.UserId


            };
        }
        public static CreateNewJournalEntryForCurrentWeekDTO ToCreateNewJournalEntryForCurrentWeekDTO(this CreateNewJournalEntryForCurrentWeekRequest CreateNewJournalEntryForCurrentWeekRequest)
        {
            return new CreateNewJournalEntryForCurrentWeekDTO
            {
                Id = (Guid)CreateNewJournalEntryForCurrentWeekRequest.Id,
                UserId = CreateNewJournalEntryForCurrentWeekRequest.UserId,
                GrowthDataId = CreateNewJournalEntryForCurrentWeekRequest.GrowthDataId,
                CurrentWeek = CreateNewJournalEntryForCurrentWeekRequest.CurrentWeek,
                Note = CreateNewJournalEntryForCurrentWeekRequest.Note,
                CurrentWeight = CreateNewJournalEntryForCurrentWeekRequest.CurrentWeight,
                SystolicBP = CreateNewJournalEntryForCurrentWeekRequest.SystolicBP,
                DiastolicBP = CreateNewJournalEntryForCurrentWeekRequest.DiastolicBP,
                HeartRateBPM = CreateNewJournalEntryForCurrentWeekRequest.HeartRateBPM,
                BloodSugarLevelMgDl = CreateNewJournalEntryForCurrentWeekRequest.BloodSugarLevelMgDl,
                SymptomNames = CreateNewJournalEntryForCurrentWeekRequest.SymptomNames ?? new List<string>(),
                MoodNotes = CreateNewJournalEntryForCurrentWeekRequest.MoodNotes,
                RelatedImages = CreateNewJournalEntryForCurrentWeekRequest.RelatedImages,
                UltraSoundImages = CreateNewJournalEntryForCurrentWeekRequest.UltraSoundImages
            };
        }
        public static EditJournalEntryDTO ToEditJournalEntryDTO(this EditJournalEntryRequest EditJournalEntryRequest)
        {
            return new EditJournalEntryDTO
            {
                Id = EditJournalEntryRequest.Id,
                Note = EditJournalEntryRequest.Note,
                CurrentWeight = EditJournalEntryRequest.CurrentWeight,
                SystolicBP = EditJournalEntryRequest.SystolicBP,
                DiastolicBP = EditJournalEntryRequest.DiastolicBP,
                HeartRateBPM = EditJournalEntryRequest.HeartRateBPM,
                BloodSugarLevelMgDl = EditJournalEntryRequest.BloodSugarLevelMgDl,
                SymptomNames = EditJournalEntryRequest.SymptomNames ?? new List<string>(),
                MoodNotes = EditJournalEntryRequest.MoodNotes,
                RelatedImages = EditJournalEntryRequest.RelatedImages,
                UltraSoundImages = EditJournalEntryRequest.UltraSoundImages
            };
        }

        
    }
}
