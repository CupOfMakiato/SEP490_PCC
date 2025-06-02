using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Category
{
    public class AddNewCategoryRequest
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string CategoryName { get; set; }

    }
}
