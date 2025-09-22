using Server.Application.DTOs.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.ChatThread
{
    public class CreateChatThreadDTO
    {
        public Guid? Id{ get; set; }
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        //public string? Status { get; set; }
    }
}
