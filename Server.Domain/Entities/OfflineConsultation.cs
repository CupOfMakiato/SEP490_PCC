using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class OfflineConsultation : BaseEntity
    {
        public ConsultationType ConsultationType { get; set; } = ConsultationType.OneTime;
        // w.i.p
    }
}
