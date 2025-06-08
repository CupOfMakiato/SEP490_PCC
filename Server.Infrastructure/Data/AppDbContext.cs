using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Tag> Tag { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
               new Role { Id = 1, RoleName = "Admin" },
               new Role { Id = 2, RoleName = "User" },
               new Role { Id = 3, RoleName = "Staff" }
            );

            //User
            modelBuilder.Entity<User>()
            .Property(u => u.Status)
            .HasConversion(
            v => v.ToString(),
            v => (StatusEnums)Enum.Parse(typeof(StatusEnums), v)
            );

            modelBuilder.Entity<Category>()
            .HasOne(c => c.CategoryCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict); // Change from Cascade to Restrict

            modelBuilder.Entity<SubCategory>()
            .HasOne(c => c.SubCategoryCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict); // Change from Cascade to Restrict

            modelBuilder.Entity<Bookmark>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
            .HasOne(c => c.CommentCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
            
            // blog

            modelBuilder.Entity<Blog>()
            .Property(s => s.Status)
            .HasConversion(v => v.ToString(), v => (BlogStatus)Enum.Parse(typeof(BlogStatus), v));

            modelBuilder.Entity<Blog>()
            .HasOne(c => c.BlogCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            // tag

            modelBuilder.Entity<Tag>()
            .Property(s => s.Status)
            .HasConversion(v => v.ToString(), v => (StatusEnums)Enum.Parse(typeof(StatusEnums), v));

            modelBuilder.Entity<Tag>()
            .HasOne(c => c.TagCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);


            // blogtag

            modelBuilder.Entity<BlogTag>()
            .HasKey(bt => new { bt.BlogId, bt.TagId });

            modelBuilder.Entity<BlogTag>()
            .HasOne(bt => bt.Blog)
            .WithMany(b => b.BlogTags)
            .HasForeignKey(bt => bt.BlogId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BlogTag>()
            .HasOne(bt => bt.Tag)
            .WithMany(t => t.BlogTags)
            .HasForeignKey(bt => bt.TagId)
            .OnDelete(DeleteBehavior.Restrict);

            // Bookmark
            modelBuilder.Entity<Bookmark>()
            .HasKey(b => new { b.UserId, b.BlogId });

            modelBuilder.Entity<Bookmark>()
                .HasOne(b => b.User)
                .WithMany(u => u.BookmarkedBlogs)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Bookmark>()
                .HasOne(b => b.Blog)
                .WithMany(b => b.BookmarkedByUsers)
                .HasForeignKey(b => b.BlogId);

            // Like
            modelBuilder.Entity<Like>()
            .HasKey(l => new { l.UserId, l.BlogId });

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.LikedBlogs)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Blog)
                .WithMany(b => b.LikedByUsers)
                .HasForeignKey(l => l.BlogId);

        }
    }
}
