﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Auth
{
    public class OtpVerificationDTO
    {
        public string Email { get; set; }
        public string Otp { get; set; }

    }
}
