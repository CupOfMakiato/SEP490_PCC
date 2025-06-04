using Server.Application.DTOs.User;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Tag
{
    public class ViewTagDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StatusEnums Status { get; set; }
        public UserDTO? CreatedByUser { get; set; }
    }
}
