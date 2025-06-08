using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class UserFollower 
    {
        public Guid FolloweeId { get; set; } // the user who we are following
        public Guid FollowerId { get; set; } // the user who following us
        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
        public User Followee { get; set; }
        public User Follower { get; set; }
        public FollowStatus Status { get; set; } = FollowStatus.Neutral;
    }
    
}
