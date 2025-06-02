using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.SubCategory
{
    public class AddSubCategoryDTO
    {
        public Guid Id { get; set; }
        public string SubCategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
