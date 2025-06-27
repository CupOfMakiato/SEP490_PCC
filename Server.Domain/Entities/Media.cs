using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Media : BaseEntity
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string FilePublicId { get; set; }
        

        [ForeignKey("BlogId")]
        public Guid? BlogId { get; set; }
        public Blog? Blog { get; set; }
        [ForeignKey("JournalId")]
        public Guid? JournalId { get; set; }
        public Journal? Journal { get; set; }
    }
}
