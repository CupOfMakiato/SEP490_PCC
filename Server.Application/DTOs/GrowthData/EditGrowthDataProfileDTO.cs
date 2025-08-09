using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.GrowthData
{
    public class EditGrowthDataProfileDTO
    {
        public Guid Id { get; set; }
        public DateTime? FirstDayOfLastMenstrualPeriod { get; set; }
        public DateTime? EstimatedDueDate { get; set; }
        public int GestationalAgeInWeeks { get; set; }
        public GrowthDataStatus Status { get; set; }
        public float? PreWeight { get; set; }
    }
}
