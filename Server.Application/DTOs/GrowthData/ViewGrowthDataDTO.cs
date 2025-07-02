using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Fetus;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.GrowthData
{
    public class ViewGrowthDataDTO
    {
        public Guid Id { get; set; }
        //public DateTime DateOfPregnancy { get; set; }
        public float PreWeight { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public int GestationalAgeInWeeks { get; set; } 
        public DateTime EstimatedDueDate { get; set; }
        public int CurrentGestationalAgeInWeeks { get; set; }
        public int CurrentTrimester { get; set; }

        public List<JournalDTO>? Journal { get; set; }
        public GetUserDTO? CreatedByUser { get; set; }
        public BasicBioMetricDTO? BasicBioMetric { get; set; }
    }
}
