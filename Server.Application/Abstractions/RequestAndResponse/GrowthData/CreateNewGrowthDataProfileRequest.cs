using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.GrowthData
{
    public class CreateNewGrowthDataProfileRequest
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }
}
