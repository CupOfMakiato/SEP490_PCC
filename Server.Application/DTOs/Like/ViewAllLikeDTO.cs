using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Like
{
    public class ViewAllLikeDTO
    {
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
