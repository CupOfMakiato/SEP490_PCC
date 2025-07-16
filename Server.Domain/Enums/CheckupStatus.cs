using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Enums
{
    public enum CheckupStatus
    {
        NotScheduled,  
        Scheduled,     
        Completed,    
        Missed,        
        Cancelled,      
        Skipped         
    }
}
