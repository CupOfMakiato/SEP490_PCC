using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Payment
{
    public class UserGrowthDto
    {
        public string Period { get; set; }
        public int NewUsers { get; set; }
        public int ActiveUsers { get; set; }
    }
}
