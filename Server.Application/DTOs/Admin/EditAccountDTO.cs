﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Admin
{
    public class EditAccountDTO
    {
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
