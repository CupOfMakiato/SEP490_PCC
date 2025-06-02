using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = false;
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        public User CategoryCreatedBy { get; set; }
    }
}
