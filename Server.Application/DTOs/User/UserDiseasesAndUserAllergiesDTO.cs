using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.User
{
    public class UserDiseasesAndUserAllergiesDTO
    {
        public List<UserDiseasesDTO> Diseases { get; set; }
        public List<UserAllergiesDTO> Allergies { get; set; }
    }
}
