using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Fetus
{
    public class FetusDTO
    {
        public Guid Id { get; set; }
        public int Week { get; set; }
        public int Trimester { get; set; }
        public float EstimatedFetalWeight { get; set; }
        public float EstimatedFetalLength { get; set; }
        public string DevelopmentMilestones { get; set; }
    }
}
