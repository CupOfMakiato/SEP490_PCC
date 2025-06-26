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
                Symptoms = (Domain.Enums.Symptom)CreateNewJournalEntryForCurrentWeekDTO.Symptoms,
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
                Symptoms = CreateNewJournalEntryForCurrentWeekRequest.Symptoms,
                MoodNotes = CreateNewJournalEntryForCurrentWeekRequest.MoodNotes,
                RelatedImages = CreateNewJournalEntryForCurrentWeekRequest.RelatedImages,
                UltraSoundImages = CreateNewJournalEntryForCurrentWeekRequest.UltraSoundImages
            };
        }
    }
}
