using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Esf;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // User Management
        public DbSet<User> User { get; set; }
        public DbSet<UserFollower> UserFollower { get; set; }
        public DbSet<Role> Role { get; set; }

        // Staff and Clinic
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        // Consultant and Scheduling
        public DbSet<Consultant> Consultant { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<OnlineConsultation> OnlineConsultation { get; set; }
        public DbSet<OfflineConsultation> OfflineConsultation { get; set; }
        public DbSet<Slot> Slot { get; set; }
        //public DbSet<Session> Session { get; set; }

        // Pregnancy Tracking
        public DbSet<GrowthData> GrowthData { get; set; }
        public DbSet<BasicBioMetric> BasicBioMetric { get; set; }
        //public DbSet<Fetus> Fetus { get; set; }
        public DbSet<CustomChecklist> CustomChecklist { get; set; }
        public DbSet<TemplateChecklist> TemplateChecklist { get; set; }
        public DbSet<TemplateChecklistGrowthData> TemplateChecklistGrowthData { get; set; }
        public DbSet<TailoredCheckupReminder> TailoredCheckupReminder { get; set; }
        public DbSet<RecommendedCheckup> RecommendedCheckup { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<RecordedSymptom> RecordedSymptom { get; set; }
        public DbSet<JournalSymptom> JournalSymptoms { get; set; }

        // Disease Management
        public DbSet<Disease> Disease { get; set; }
        public DbSet<DiseaseGrowthData> DiseaseGrowthData { get; set; }
        public DbSet<FoodDisease> FoodDisease { get; set; }

        // Allergy Management
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<AllergyCategory> AllergyCategory { get; set; }
        public DbSet<UserAllergy> UserAllergy { get; set; }
        public DbSet<FoodAllergy> FoodAllergy { get; set; }

        // Nutrition System
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<Nutrient> Nutrient { get; set; }
        public DbSet<NutrientCategory> NutrientCategory { get; set; }
        public DbSet<FoodNutrient> FoodNutrient { get; set; }
        public DbSet<DishesRecommendationHistory> FoodRecommendationHistory { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<FoodDish> FoodDishes { get; set; }
        public DbSet<NSAttribute> Attributes { get; set; }
        public DbSet<NutrientSuggestionAttribute> NutrientSuggestionsAttributes { get; set; }

        // Blogging System
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<EnergySuggestion> EnergySuggestion { get; set; }
        public DbSet<AgeGroup> AgeGroup { get; set; }
        public DbSet<NutrientSuggetion> NutrientSuggetion { get; set; }
        public DbSet<HistoryDish> HistoryDishes { get; set; }

        // Messaging
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatThread> ChatThread { get; set; }

        // Payment and Subscription
        public DbSet<SubscriptionPlan> SubscriptionPlan { get; set; }
        public DbSet<UserSubscription> UserSubscription { get; set; }
        public DbSet<Payment> Payment { get; set; }

        // Doctor
        public DbSet<Doctor> Doctor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
               new Role { Id = 1, RoleName = "Admin" },
               new Role { Id = 2, RoleName = "User" },
               new Role { Id = 3, RoleName = "HealthExpert" },
               new Role { Id = 4, RoleName = "NutrientSpecialist" },
               new Role { Id = 5, RoleName = "Clinic" },
               new Role { Id = 6, RoleName = "Consultant" },
               new Role { Id = 7, RoleName = "Doctor" }
            );

            modelBuilder.Entity<User>().HasData(
               new User { Id = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"), UserName = "Administrator", Email = "passswp@gmail.com", Password = "$2y$10$4TyXDqqGDcs1xNAgD0mptec9AcdOwPc57jYjE/AzUqBqXmzc1vyie", Status = StatusEnums.Active, RoleId = 1, IsVerified = true, PhoneNumber = "123456789", Address = "District 2, Ho Chi Minh city", CreationDate = DateTime.Now, IsDeleted = false },
               new User { Id = Guid.Parse("5de81f1c-c715-46c1-b40a-7dcbfe25cafa"), UserName = "TestHealth", Email = "nguyenbr23@gmail.com", Password = "$2y$10$Ll0VAQfmgd6kUzUzmM7dxOkHHUFTd4kD5WZSKVcmdy1jGNGL1giCi", Status = StatusEnums.Active, RoleId = 3, IsVerified = true, PhoneNumber = "123456789", Address = "Dong Nai", CreationDate = DateTime.Now, IsDeleted = false },
               new User { Id = Guid.Parse("7e4fd68f-7a71-4dbf-873a-0605b72a64ec"), UserName = "TestNutrient", Email = "swdproject73@gmail.com", Password = "$2y$10$vpseCsSPCEa7fHNdo7fJX.Fg9x/r2vXjzh3FpmUKezOevJIFKpvMe", Status = StatusEnums.Active, RoleId = 4, IsVerified = true, PhoneNumber = "123456789", Address = "Go Vap District, Ho Chi Minh city", CreationDate = DateTime.Now, IsDeleted = false },
               new User { Id = Guid.Parse("9fac4a22-9bda-45b0-a41a-fdf93ea72a39"), UserName = "TestClinic", Email = "nguyenlmse171333@fpt.edu.vn", Password = "$2y$10$3.0ODOCeEea3SbAWoD51Z.x8A8tSZJ3srprmvkw0xvXsbHdH/D9Rq", Status = StatusEnums.Active, RoleId = 5, IsVerified = true, PhoneNumber = "123456789", Address = "Thu Duc city", CreationDate = DateTime.Now, IsDeleted = false },
               new User { Id = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"), UserName = "NguyenLe", Email = "swpproject406@gmail.com", Password = "$2y$10$cITY98BqKNmttf6aCa.PeeOjqJCPKNoqTcUZSkOcBfH0ltD3Yjn/i", Status = StatusEnums.Active, RoleId = 2, IsVerified = true, PhoneNumber = "123456789", Address = "District 7, Ho Chi Minh city", CreationDate = DateTime.Now, IsDeleted = false }

           );

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = Guid.Parse("6965593b-bb35-429f-921b-9da9ab3a4b56"), CategoryName = "Pregnancy Nutrition", BlogCategoryTag = BlogCategoryTag.Nutrient , IsActive = true },
               new Category { Id = Guid.Parse("cee75f47-2420-4ae4-bfe7-863ca98b649b"), CategoryName = "Prenatal Care", BlogCategoryTag = BlogCategoryTag.Health, IsActive = true },
               new Category { Id = Guid.Parse("371e3ddc-e996-45d3-8d67-2c95026b7f2d"), CategoryName = "Mental Health & Wellness", BlogCategoryTag = BlogCategoryTag.Health, IsActive = true },
               new Category { Id = Guid.Parse("f2080622-9e3d-4d93-a75b-285efbb05dea"), CategoryName = "Labor & Delivery", BlogCategoryTag = BlogCategoryTag.Health, IsActive = true },
               new Category { Id = Guid.Parse("a0a60b5d-5f7c-4a86-9efd-1d87de0e382a"), CategoryName = "Postpartum & Newborn Care", BlogCategoryTag = BlogCategoryTag.Health, IsActive = true }
           );

            modelBuilder.Entity<GrowthData>().HasData(
               new GrowthData
               {
                   Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e6"),
                   //Height = 160,
                   //Weight = 60,
                   FirstDayOfLastMenstrualPeriod = new DateTime(2024, 11, 26),
                   EstimatedDueDate = new DateTime(2025, 09, 02),
                   CreatedBy = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"), 
                   Status = GrowthDataStatus.Active,
                   CreationDate = DateTime.Now,
                   IsDeleted = false
               }
            );
            modelBuilder.Entity<BasicBioMetric>().HasData(
                new BasicBioMetric
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e7"),
                    GrowthDataId = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e6"),
                    HeightCm = 160,
                    WeightKg = 60,
                    Notes = "I have no chronic diseases!",
                    CreatedBy = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    CreationDate = DateTime.Now,
                    IsDeleted = false
                }
                );
            modelBuilder.Entity<RecordedSymptom>().HasData(
                new RecordedSymptom
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e8"),
                    SymptomName = "Nausea",
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsTemplate = true,
                    IsDeleted = false
                },
                new RecordedSymptom
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e9"),
                    SymptomName = "Fatigue",
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsTemplate = true,
                    IsDeleted = false
                },
                new RecordedSymptom
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5ea"),
                    SymptomName = "Headache",
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsTemplate = true,
                    IsDeleted = false
                },
                new RecordedSymptom
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5eb"),
                    SymptomName = "Backache",
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsTemplate = true,
                    IsDeleted = false
                },
                new RecordedSymptom
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5ec"),
                    SymptomName = "Dizziness",
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsTemplate = true,
                    IsDeleted = false
                },
                new RecordedSymptom
                {
                    Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5ed"),
                    SymptomName = "None",
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsTemplate = true,
                    IsDeleted = false
                }
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

            modelBuilder.Entity<Blog>()
            .HasOne(b => b.Category)
            .WithMany(c => c.Blogs)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<NSAttribute>()
                .HasOne(n => n.Nutrient)
                .WithMany()
                .HasForeignKey(c => c.NutrientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nutrient>()
                .HasMany(n => n.Attributes)
                .WithOne()
                .HasForeignKey(c => c.Id)
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

            //EnergySuggestion
            modelBuilder.Entity<EnergySuggestion>()
                .HasOne(e => e.AgeGroup)
                .WithMany(a => a.EnergySuggestions)
                .HasForeignKey(e => e.AgeGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NutrientSuggestionAttribute>()
                .HasKey(nsa => nsa.NutrientSuggestionAttributeId);

            modelBuilder.Entity<NutrientSuggestionAttribute>()
                .HasIndex(nsa => new { nsa.NutrientSuggetionId, nsa.AttributeId, nsa.AgeGroudId })
                .IsUnique();


            //NSAttribute
            modelBuilder.Entity<NSAttribute>()
            .HasOne(nsa => nsa.Nutrient)
            .WithMany(n => n.Attributes)
            .HasForeignKey(nsa => nsa.NutrientId)
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

            // Food Vitamin

            modelBuilder.Entity<FoodNutrient>()
            .HasKey(bt => new { bt.FoodId, bt.NutrientId });

            modelBuilder.Entity<FoodNutrient>()
            .HasOne(bt => bt.Food)
            .WithMany(b => b.FoodNutrients)
            .HasForeignKey(bt => bt.FoodId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodNutrient>()
            .HasOne(bt => bt.Nutrient)
            .WithMany(t => t.FoodNutrients)
            .HasForeignKey(bt => bt.NutrientId)
            .OnDelete(DeleteBehavior.Restrict);

            // DiseaseGrowthData

            modelBuilder.Entity<DiseaseGrowthData>()
            .HasKey(bt => new { bt.DiseaseId, bt.GrowDataId });

            modelBuilder.Entity<DiseaseGrowthData>()
            .HasOne(bt => bt.Disease)
            .WithMany(b => b.DiseaseGrowthData)
            .HasForeignKey(bt => bt.DiseaseId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DiseaseGrowthData>()
            .HasOne(bt => bt.GrowthData)
            .WithMany(t => t.DiseaseGrowthData)
            .HasForeignKey(bt => bt.GrowDataId)
            .OnDelete(DeleteBehavior.Restrict);

            //Dishs
            modelBuilder.Entity<FoodDish>()
            .HasKey(fd => new { fd.FoodId, fd.DishId });

            modelBuilder.Entity<DishMeal>()
            .HasKey(dm => new { dm.DishId, dm.MealId });

            modelBuilder.Entity<HistoryDish>()
            .HasKey(hd => new { hd.DishId, hd.DishesRecommendationHistoryId });

            // FoodAllergy

            modelBuilder.Entity<FoodAllergy>()
            .HasKey(bt => new { bt.FoodId, bt.AllergyId });

            modelBuilder.Entity<FoodAllergy>()
            .HasOne(bt => bt.Food)
            .WithMany(b => b.FoodAllergies)
            .HasForeignKey(bt => bt.FoodId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodAllergy>()
            .HasOne(bt => bt.Allergy)
            .WithMany(t => t.FoodAllergy)
            .HasForeignKey(bt => bt.AllergyId)
            .OnDelete(DeleteBehavior.Restrict);

            // FoodDisease

            modelBuilder.Entity<FoodDisease>()
            .HasKey(bt => new { bt.FoodId, bt.DiseaseId });

            modelBuilder.Entity<FoodDisease>()
            .HasOne(bt => bt.Food)
            .WithMany(f => f.FoodDiseases)
            .HasForeignKey(bt => bt.FoodId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodDisease>()
            .HasOne(bt => bt.Disease)
            .WithMany(t => t.FoodDisease)
            .HasForeignKey(bt => bt.DiseaseId)
            .OnDelete(DeleteBehavior.Restrict);

            // UserAllergy

            modelBuilder.Entity<UserAllergy>()
            .HasKey(bt => new { bt.UserId, bt.AllergyId });

            modelBuilder.Entity<UserAllergy>()
            .HasOne(bt => bt.User)
            .WithMany(b => b.UserAllergy)
            .HasForeignKey(bt => bt.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAllergy>()
            .HasOne(bt => bt.Allergy)
            .WithMany(t => t.UserAllergy)
            .HasForeignKey(bt => bt.AllergyId)
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

            // follow
            modelBuilder.Entity<UserFollower>()
                .HasKey(uf => new { uf.FollowerId, uf.FolloweeId });

            modelBuilder.Entity<UserFollower>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Followees)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollower>()
                .HasOne(uf => uf.Followee)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FolloweeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollower>()
                .Property(f => f.Status)
                .HasConversion(
                v => v.ToString(),
                v => (FollowStatus)Enum.Parse(typeof(FollowStatus), v));

            // comment
            modelBuilder.Entity<Comment>()
            .HasOne(c => c.CommentCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .Property(f => f.Status)
                .HasConversion(
                v => v.ToString(),
                v => (CommentStatus)Enum.Parse(typeof(CommentStatus), v));

            // Message 

            modelBuilder.Entity<ChatThread>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChatThread>()
                .HasOne(m => m.Consultant)
                .WithMany()
                .HasForeignKey(m => m.ConsultantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ChatThread)
                .WithMany(ct => ct.Messages)
                .HasForeignKey(m => m.ChatThreadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Consultation

            modelBuilder.Entity<OnlineConsultation>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OnlineConsultation>()
                .HasOne(c => c.Consultant)
                .WithMany()
                .HasForeignKey(c => c.ConsultantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OfflineConsultation>()
                .Property(f => f.ConsultationType)
                .HasConversion(
                v => v.ToString(),
                v => (ConsultationType)Enum.Parse(typeof(ConsultationType), v));

            modelBuilder.Entity<OfflineConsultation>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OfflineConsultation>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OfflineConsultation>()
                .HasOne(c => c.Clinic)
                .WithMany()
                .HasForeignKey(c => c.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            // GrowthData

            modelBuilder.Entity<GrowthData>()
            .HasOne(c => c.GrowthDataCreatedBy)
            .WithMany(c => c.GrowthData)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GrowthData>()
                .Property(f => f.Status)
                .HasConversion(
                v => v.ToString(),
                v => (GrowthDataStatus)Enum.Parse(typeof(GrowthDataStatus), v));

            // Journal
            modelBuilder.Entity<Journal>()
            .Property(s => s.MoodNotes)
            .HasConversion(v => v.ToString(), v => (Mood)Enum.Parse(typeof(Mood), v));

            //modelBuilder.Entity<Journal>()
            //.Property(s => s.Symptoms)
            //.HasConversion(v => v.ToString(), v => (Symptom)Enum.Parse(typeof(Symptom), v));

            modelBuilder.Entity<Journal>()
            .HasOne(c => c.JournalCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            // Media
            modelBuilder.Entity<Media>()
            .HasOne(m => m.Blog)
            .WithMany(b => b.Media)
            .HasForeignKey(m => m.BlogId)
            .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Media>()
            .HasOne(m => m.Journal)
            .WithMany(j => j.Media)
            .HasForeignKey(m => m.JournalId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasOne(u => u.Avatar)
            .WithOne(m => m.User)
            .HasForeignKey<Media>(m => m.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Media>()
            .HasOne(u => u.OfflineConsultation)
            .WithMany(m => m.Attachments)
            .HasForeignKey(m => m.OfflineConsultationId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Media>()
            .HasOne(u => u.OnlineConsultation)
            .WithMany(m => m.Attachments)
            .HasForeignKey(m => m.OnlineConsultationId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Media>()
            .HasOne(u => u.Clinic)
            .WithOne(m => m.ImageUrl)
            .HasForeignKey<Media>(m => m.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Media>()
            .HasOne(u => u.Message)
            .WithMany(m => m.Media)
            .HasForeignKey(m => m.MessageId)
            .OnDelete(DeleteBehavior.Restrict);

            // Category
            modelBuilder.Entity<Category>()
           .Property(s => s.BlogCategoryTag)
           .HasConversion(v => v.ToString(), v => (BlogCategoryTag)Enum.Parse(typeof(BlogCategoryTag), v));

            // BasicBioMetric
            modelBuilder.Entity<BasicBioMetric>()
            .HasOne(b => b.GrowthData)
            .WithOne(g => g.BasicBioMetric)
            .HasForeignKey<BasicBioMetric>(b => b.GrowthDataId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BasicBioMetric>()
            .HasOne(c => c.BasicBioMetricCreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            // Symptom
            modelBuilder.Entity<JournalSymptom>()
            .HasKey(bt => new { bt.JournalId, bt.RecordedSymptomId });

            modelBuilder.Entity<JournalSymptom>()
            .HasOne(bt => bt.Journal)
            .WithMany(b => b.JournalSymptoms)
            .HasForeignKey(bt => bt.JournalId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JournalSymptom>()
            .HasOne(bt => bt.RecordedSymptom)
            .WithMany(t => t.JournalSymptoms)
            .HasForeignKey(bt => bt.RecordedSymptomId)
            .OnDelete(DeleteBehavior.Restrict);

            // TailoredCheckupReminder

            modelBuilder.Entity<TailoredCheckupReminder>()
                .Property(s => s.Type)
                .HasConversion(v => v.ToString(), v => (CheckupType)Enum.Parse(typeof(CheckupType), v));

            modelBuilder.Entity<TailoredCheckupReminder>()
                .Property(s => s.CheckupStatus)
                .HasConversion(v => v.ToString(), v => (CheckupStatus)Enum.Parse(typeof(CheckupStatus), v));

            modelBuilder.Entity<TailoredCheckupReminder>()
            .HasOne(uc => uc.GrowthData)
            .WithMany(gd => gd.TailoredCheckupReminders)
            .HasForeignKey(uc => uc.GrowthDataId)
            .OnDelete(DeleteBehavior.Cascade);

            // CustomChecklist

            modelBuilder.Entity<CustomChecklist>()
            .HasOne(uc => uc.GrowthData)
            .WithMany(gd => gd.CustomChecklists)
            .HasForeignKey(uc => uc.GrowthDataId)
            .OnDelete(DeleteBehavior.Cascade);

            // Template Checklist

            modelBuilder.Entity<TemplateChecklistGrowthData>()
            .HasKey(bt => new { bt.GrowthDataId, bt.TemplateChecklistId});

            modelBuilder.Entity<TemplateChecklistGrowthData>()
            .HasOne(bt => bt.GrowthData)
            .WithMany(b => b.TemplateChecklistGrowthDatas)
            .HasForeignKey(bt => bt.GrowthDataId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TemplateChecklistGrowthData>()
            .HasOne(bt => bt.TemplateChecklist)
            .WithMany(t => t.TemplateChecklistGrowthDatas)
            .HasForeignKey(bt => bt.TemplateChecklistId)
            .OnDelete(DeleteBehavior.Restrict);

            ChecklistSeedData.SeedData(modelBuilder);

            // RecommendedCheckup
            modelBuilder.Entity<RecommendedCheckup>()
                .Property(s => s.Type)
                .HasConversion(v => v.ToString(), v => (CheckupType)Enum.Parse(typeof(CheckupType), v));

            modelBuilder.Entity<RecommendedCheckupGrowthData>()
            .HasKey(bt => new { bt.GrowthDataId, bt.RecommendedCheckupId});

            modelBuilder.Entity<RecommendedCheckupGrowthData>()
            .HasOne(bt => bt.GrowthData)
            .WithMany(b => b.RecommendedCheckupGrowthDatas)
            .HasForeignKey(bt => bt.GrowthDataId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecommendedCheckupGrowthData>()
            .HasOne(bt => bt.RecommendedCheckup)
            .WithMany(t => t.RecommendedCheckupGrowthDatas)
            .HasForeignKey(bt => bt.RecommendedCheckupId)
            .OnDelete(DeleteBehavior.Restrict);

            CheckupSeedData.SeedData(modelBuilder);

            // SubscriptionPlan

            modelBuilder.Entity<UserSubscription>()
            .HasOne(us => us.SubscriptionPlan)
            .WithMany(sp => sp.UserSubscriptions)
            .HasForeignKey(us => us.SubscriptionPlanId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSubscription>()
            .HasOne(us => us.User)
            .WithMany(u => u.UserSubscriptions)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSubscription>()
                .Property(s => s.PaymentMethod)
                .HasConversion(v => v.ToString(), v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v));

            modelBuilder.Entity<SubscriptionPlan>()
                .Property(s => s.SubscriptionType)
                .HasConversion(v => v.ToString(), v => (SubscriptionType)Enum.Parse(typeof(SubscriptionType), v));

            modelBuilder.Entity<SubscriptionPlan>()
                .Property(s => s.SubscriptionName)
                .HasConversion(v => v.ToString(), v => (SubscriptionName)Enum.Parse(typeof(SubscriptionName), v));

            // Consultant

            modelBuilder.Entity<Consultant>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Consultants)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consultant>()
                .HasOne(c => c.User)
                .WithOne(u => u.Consultant)
                .HasForeignKey<Consultant>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(c => c.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Schedule

            //modelBuilder.Entity<Schedule>()
            //    .HasOne(s => s.Consultant)
            //    .WithMany(c => c.Schedules)
            //    .HasForeignKey(s => s.ConsultantId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Slot)
                .WithMany()
                .HasForeignKey(s => s.SlotId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Doctor)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
