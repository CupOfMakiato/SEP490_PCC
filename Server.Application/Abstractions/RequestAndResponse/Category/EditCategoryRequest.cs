using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Category
{
    public class EditCategoryRequest
    {
        public Guid Id { get; set; }
        //public Guid ModifiedBy { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public BlogCategoryTag BlogCategoryTag { get; set; }

    }
}
