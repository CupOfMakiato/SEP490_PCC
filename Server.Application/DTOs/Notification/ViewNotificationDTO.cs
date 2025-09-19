using Server.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Notification
{
    public class ViewNotificationDTO
    {
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public bool IsSent { get; set; } = false;
        public GetUserDTO? CreatedByUser { get; set; }
    }
}
