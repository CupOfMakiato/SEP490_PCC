﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Bookmark : ConfigEntity
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
        public DateTime BookmarkedAt { get; set; } = DateTime.UtcNow;
    } 
}
