using Server.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Server.Domain.Entities
{
    public class User : BaseEntity
    {
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public double? Balance { get; set; }
        public string? RefreshToken { get; set; }
        public StatusEnums Status { get; set; }
        public string? Otp { get; set; }
        public bool IsVerified { get; set; } = false;
        public DateTime? OtpExpiryTime { get; set; }
        public string? VerificationToken { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public bool? IsStaff { get; set; } = false;
        public string? Address { get; set; }
        // Avatar image
        public Media? Avatar { get; set; }
        // OAuth
        public string? Provider { get; set; }
        public string? ProviderKey { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public Doctor Doctor { get; set; }
        public Consultant Consultant { get; set; }
        public Clinic Clinic { get; set; }
        public IEnumerable<GrowthData>? GrowthData { get; set; }

        // user can like many blogs
        public ICollection<Like> LikedBlogs { get; set; }

        // user can bookmark many blogs
        public ICollection<Bookmark> BookmarkedBlogs { get; set; }

        // Users that this user is following
        public ICollection<UserFollower> Followees { get; set; }

        // Users that are following this user
        public ICollection<UserFollower> Followers { get; set; }
        public ICollection<UserAllergy> UserAllergy { get; set; } = new List<UserAllergy>();
        public ICollection<UserSubscription> UserSubscriptions { get; set; }

    }
}
