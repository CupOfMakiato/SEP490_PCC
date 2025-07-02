using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.GrowthData
{
    public class EditGrowthDataProfileRequest
    {
        public Guid? Id { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public DateTime EstimatedDueDate { get; set; }
        public float? PreWeight { get; set; }
    }
}
