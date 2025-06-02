using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Category
{
    public class AddCategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
