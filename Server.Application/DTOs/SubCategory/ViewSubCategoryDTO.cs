using Server.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.SubCategory
{
    public class ViewSubCategoryDTO
    {
        public Guid Id { get; set; }
        public string SubCategoryName { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
        public UserDTO? CreatedByUser { get; set; }
    }
}
