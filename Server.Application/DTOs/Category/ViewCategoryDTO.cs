using Server.Application.DTOs.User;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Category
{
    public class ViewCategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public BlogCategoryTag BlogCategoryTag { get; set; } = BlogCategoryTag.Health;
        public UserDTO? CreatedByUser { get; set; }
    }
}
