using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Journal : BaseEntity
    {
        public Guid GrowthDataId { get; set; }
        public int Week { get; set; }
        public int Trimester { get; set; }
        public string Note { get; set; }
        public float CurrentWeight { get; set; }
        public string Symptoms { get; set; }
        public string MoodNotes { get; set; }

        public GrowthData GrowthData { get; set; }

        // List of images
        public ICollection<Media> Media { get; set; } = new List<Media>();
    }
}
