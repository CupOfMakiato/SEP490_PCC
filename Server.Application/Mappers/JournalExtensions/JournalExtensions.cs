using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.Abstractions.RequestAndResponse.Journal;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.Interfaces;
using Server.Domain.Entities;
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
            return new Journal
            {
                Id = CreateNewJournalEntryForCurrentWeekDTO.Id,
                GrowthDataId = CreateNewJournalEntryForCurrentWeekDTO.GrowthDataId,
                CurrentWeek = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeek,
                CurrentTrimester = CreateNewJournalEntryForCurrentWeekDTO.CurrentTrimester,
                Note = CreateNewJournalEntryForCurrentWeekDTO.Note,
                CurrentWeight = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeight,
                JournalSymptoms = new List<JournalSymptom>(),
                MoodNotes = (Domain.Enums.Mood)CreateNewJournalEntryForCurrentWeekDTO.MoodNotes,
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
                CurrentTrimester = CreateNewJournalEntryForCurrentWeekRequest.CurrentTrimester,
                Note = CreateNewJournalEntryForCurrentWeekRequest.Note,
                CurrentWeight = CreateNewJournalEntryForCurrentWeekRequest.CurrentWeight,
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
                Id = (Guid)EditJournalEntryRequest.Id,
                Note = EditJournalEntryRequest.Note,
                CurrentWeight = EditJournalEntryRequest.CurrentWeight,
                SymptomNames = EditJournalEntryRequest.SymptomNames ?? new List<string>(),
                MoodNotes = EditJournalEntryRequest.MoodNotes,
                RelatedImages = EditJournalEntryRequest.RelatedImages,
                UltraSoundImages = EditJournalEntryRequest.UltraSoundImages
            };
        }
    }
}
