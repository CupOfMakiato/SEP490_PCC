using Server.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Journal
{
    public class ViewJournalDTO
    {
        public Guid Id { get; set; }
        public int CurrentWeek { get; set; }
        public int CurrentTrimester { get; set; }
        public string Note { get; set; }
        public float CurrentWeight { get; set; }
        public string Symptoms { get; set; }
        public string MoodNotes { get; set; }
        public GetUserDTO? CreatedByUser { get; set; }
    }
}
