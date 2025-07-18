﻿using Server.Application.DTOs.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.User
{
    public class GetUserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Status { get; set; }
        public MediaDTO? Avatar { get; set; }
        public int RoleId { get; set; }
    }
}
