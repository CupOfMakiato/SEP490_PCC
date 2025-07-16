using Server.Application.DTOs.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.User
{
    public class EditUserDTO
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
