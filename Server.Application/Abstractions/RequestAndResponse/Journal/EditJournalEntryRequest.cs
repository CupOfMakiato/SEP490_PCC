using Microsoft.AspNetCore.Http;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Journal
{
    public class EditJournalEntryRequest
    {
        public Guid? Id { get; set; }
        public string Note { get; set; }
        public float CurrentWeight { get; set; }
        public Symptom? Symptoms { get; set; }
        public Mood? MoodNotes { get; set; }
        public List<IFormFile>? RelatedImages { get; set; }
        public List<IFormFile>? UltraSoundImages { get; set; }
    }
}
