using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class SuggestionRule : BaseEntity
    {
        public int? MinWeek { get; set; }
        public int? MaxWeek { get; set; }
        public int? Trimester { get; set; }

        public string Condition { get; set; }
        public string Note { get; set; }

        public ICollection<Food> Foods { get; set; }

        public ICollection<Disease> Diseases { get; set; }

        public bool IsPositive { get; set; }
    }
}
